using RA2Mod;
using RA2Mod.General;
using RA2Mod.Minions.TeslaTower.Components;
using RA2Mod.Survivors.Tesla.SkillDefs;
using RoR2;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputBankTest))]
public class TeslaTrackerComponent : MonoBehaviour {

    public delegate void OnSearchEvent();
    public OnSearchEvent SearchEvent;

    public float maxTrackingDistance = 50f;

    public float trackingRadius = 4f;
    public float trackingMaxAngleZap = 13;
    public float trackingAngleLenience => GeneralConfig.zapLenienceAngle;

    public float trackerUpdateFrequency = 16f;

    public HurtBox trackingTargetZap;
    public HurtBox trackingTargetDash;

    public List<HealthComponent> dashCooldownTargets = new List<HealthComponent>();
    public List<float> dashCooldownTimers = new List<float>();
    
    private InputBankTest inputBank;

    private float trackerUpdateStopwatch;

    public bool searchingForZap;
    public bool searchingForDash;

    [SerializeField] 
    private bool searchPoint;

    void Start()
    {
        inputBank = base.GetComponent<InputBankTest>();
    }

    private void FixedUpdate() {

        trackerUpdateStopwatch += Time.fixedDeltaTime;
        if (trackerUpdateStopwatch >= 1f / trackerUpdateFrequency) {
            OnSearch();
        }
        UpdateDashCooldownTimers();
    }

    private void UpdateDashCooldownTimers() {
        for (int i = dashCooldownTimers.Count - 1; i >= 0; i--) {

            if(dashCooldownTargets[i] == null) {
                dashCooldownTargets.RemoveAt(i);
                dashCooldownTimers.RemoveAt(i);
                continue;
            }

            dashCooldownTimers[i] -= Time.fixedDeltaTime;
            if(dashCooldownTimers[i] < 0) {
                dashCooldownTargets.RemoveAt(i);
                dashCooldownTimers.RemoveAt(i);
            }
        }
    }

    public void AddCooldownTarget(HealthComponent healthComponent) {

        if (dashCooldownTargets.Contains(healthComponent))
            return;

        dashCooldownTargets.Add(healthComponent);
        dashCooldownTimers.Add(4);
    }

    private void OnSearch() {

        trackerUpdateStopwatch -= 1f / trackerUpdateFrequency;
        Ray aimRay = new Ray(inputBank.aimOrigin, inputBank.aimDirection);

        FindTrackingTarget(aimRay);

        ZappableTower zappableTower;
        if (trackingTargetZap && trackingTargetZap.hurtBoxGroup && trackingTargetZap.hurtBoxGroup.TryGetComponent<ZappableTower>(out zappableTower)) {
            trackingTargetZap = zappableTower.MainHurtbox;
        }

        SearchEvent?.Invoke();
    }

    #region search
    
    private bool FindTrackingTarget(Ray aimRay) {

        if (!searchingForZap && !searchingForDash)
            return false;

        bool found = searchPoint? SearchForTargetPoint(aimRay) : false;
        if (!found)
        {
            found = SearchForTargetSphere(aimRay, trackingRadius);
        }

        return found;
    }

    private bool SearchForTargetPoint(Ray aimRay) {

        return CharacterRaycast(gameObject, aimRay, out trackingTargetZap, out trackingTargetDash, maxTrackingDistance + trackingRadius, LayerIndex.CommonMasks.bullet, QueryTriggerInteraction.Ignore);
    }

    private bool SearchForTargetSphere(Ray aimRay, float radius) {

        return CharacterSpherecast(gameObject, aimRay, radius, out trackingTargetZap, out trackingTargetDash, maxTrackingDistance, LayerIndex.CommonMasks.bullet, QueryTriggerInteraction.Ignore);
    }

    private bool SearchForDashTarget(Ray aimRay, float radius) {

        return CharacterSpherecast(gameObject, aimRay, radius, out _, out trackingTargetDash, maxTrackingDistance, LayerIndex.CommonMasks.bullet, QueryTriggerInteraction.Ignore);
    }

    #endregion search

    #region hurtbox raycast

    //// Token: 0x06003E56 RID: 15958 RVA: 0x00101B5C File Offset: 0x000FFD5C
    public bool CharacterRaycast(GameObject bodyObject, Ray ray, out HurtBox zapHit, out HurtBox dashHit, float maxDistance, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction) {
        RaycastHit[] hits = Physics.RaycastAll(ray, maxDistance, layerMask, queryTriggerInteraction);
        return HandleCharacterPhysicsCastResults(bodyObject, ray, queryTriggerInteraction, hits, out zapHit, out dashHit);
    }

    // Token: 0x06003E57 RID: 15959 RVA: 0x00101B84 File Offset: 0x000FFD84
    public bool CharacterSpherecast(GameObject bodyObject, Ray ray, float radius, out HurtBox zapHit, out HurtBox dashHit, float maxDistance, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction) {
        RaycastHit[] hits = Physics.SphereCastAll(ray, radius, maxDistance, layerMask, queryTriggerInteraction);
        return HandleCharacterPhysicsCastResults(bodyObject, ray, queryTriggerInteraction, hits, out zapHit, out dashHit);
    }

    // Token: 0x06003E55 RID: 15957 RVA: 0x00101AA8 File Offset: 0x000FFCA8
    public bool HandleCharacterPhysicsCastResults(GameObject bodyObject, 
                                                  Ray ray, 
                                                  QueryTriggerInteraction queryTriggerInteraction, 
                                                  RaycastHit[] hits, 
                                                  out HurtBox zapHit, 
                                                  out HurtBox dashHit)
    {
        var self = this;
        zapHit = null;
        dashHit = null;

        float currentDashDistance = float.PositiveInfinity;
        float currentZapDistance = float.PositiveInfinity;
        float closestZapAngle = 360;
        float closestDashAngle = 360;

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider == null)
                continue;
            HurtBox hurtBox = hits[i].collider.GetComponent<HurtBox>();
            if (hurtBox == null)
                continue;
            if (hurtBox.healthComponent == null)
                continue;
            if (hurtBox.healthComponent.gameObject == bodyObject)
                continue;
            if (hurtBox.hurtBoxGroup == null)
                continue;

            //if within the initial sphere of the spherecast, hit.point is 0,0,0 which is very bad. go by transform position instead
            Vector3 point = hits[i].point == default ? hits[i].collider.transform.position : hits[i].point;

            bool isTower = hurtBox.hurtBoxGroup.GetComponent<ZappableTower>();

            //cast a line to see if it is interrupted by world
            //however the tesla tower is also world so exclude that
            if (!isTower)
            {
                bool lineOfSightBlocked = Physics.Linecast(point, ray.origin, out RaycastHit hitInfo, LayerIndex.world.mask, queryTriggerInteraction);
                if (lineOfSightBlocked)
                    continue;
            }

            float distance = hits[i].distance;
            //angle to hit point or angle to hurtbox center. whichever is closer to crosshair
            float angle = Mathf.Min(Vector3.Angle(point - ray.origin, ray.direction), Vector3.Angle(hits[i].transform.position - ray.origin, ray.direction));

            string log = $"{hurtBox.healthComponent.name} {hurtBox.transform.parent.name}".PadRight(35) +
                $"| dist {distance.ToString("0.0")}".PadRight(12) +
                $"| angl {angle.ToString("0.0")}".PadRight(12) +
                $"| distC {(currentZapDistance == float.PositiveInfinity ? "inf" : currentZapDistance.ToString("0.0"))}".PadRight(12) +
                $"| anglC {closestZapAngle.ToString("0.0")}".PadRight(13) +
                $"| zapHit {(zapHit == null ? "null" : zapHit.transform.parent.name)}".PadRight(30);

            if (self.searchingForZap && angle < self.trackingMaxAngleZap)
            {
                bool closeJudgeDistance = Mathf.Abs(closestZapAngle - angle) < self.trackingAngleLenience;

                //if angles are near enough, go by distance, if not, prioritize angle
                if (closeJudgeDistance ? distance < currentZapDistance : angle < closestZapAngle + self.trackingAngleLenience)
                {
                    zapHit = hurtBox;
                    currentZapDistance = distance;
                    closestZapAngle = angle;
                }

                log += $"| judge {closeJudgeDistance}";
            }
            if (self.searchingForDash && !self.dashCooldownTargets.Contains(hurtBox.healthComponent))
            {
                bool closeJudgeDistance = Mathf.Abs(closestDashAngle - angle) < self.trackingAngleLenience;

                //if angles are near enough, go by distance, if not, prioritize angle
                if (closeJudgeDistance ? distance < currentDashDistance : angle < closestDashAngle + self.trackingAngleLenience)
                {
                    dashHit = hurtBox;
                    currentDashDistance = distance;
                    closestDashAngle = angle;
                }
            }
            //Log.Warning(log);
        }

        //Log.Warning($"zapHit {zapHit?.transform.parent.name}");
        if (zapHit == null && dashHit == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    #endregion hurtbox raycast

}
