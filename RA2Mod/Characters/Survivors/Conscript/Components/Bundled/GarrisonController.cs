using RoR2.UI;
using RoR2;
using RoR2.HudOverlay;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace RA2Mod.Survivors.Conscript.Components.Bundled
{
    public class GarrisonController : NetworkBehaviour
    {
        [SerializeField]
        private CharacterBody thisBody;
        [SerializeField]
        private GenericOwnership ownershipComponent;
        [SerializeField]
        private HealthComponent healthComponent;
        [SerializeField]
        private TeamFilter teamFilter;
        [SerializeField]
        private TeamComponent teamFilter2;
        [SerializeField]
        private GarrisonModel model;

        private OverlayController _overlayController;

        private bool _hasLived;

        private float _takeDamageInterval = 0.2f;
        private float _takeDamageTim;
        //anyone reading this, don't do this. just make your spawned thing a body and give it a master and do mastersummon.perform
        //I reinvented the wheel before I realized that's what I was doing lol
        [ClientRpc]
        public void RpcInit(GameObject ownerBody)
        {
            CharacterBody ownerCharacterBody = ownerBody.GetComponent<CharacterBody>();
            
            if (NetworkServer.active)
            {
                ownershipComponent.ownerObject = ownerCharacterBody.gameObject;
            }

            thisBody.baseMaxHealth = ownerCharacterBody.maxHealth * ConscriptConfig.M4_Garrison_Health_Multiplier;
            thisBody.baseMaxShield = ownerCharacterBody.maxShield * ConscriptConfig.M4_Garrison_Health_Multiplier;
            thisBody.baseRegen = -thisBody.baseMaxHealth / ConscriptConfig.M4_Garrison_Duration;
            thisBody.armor = ownerCharacterBody.armor;

            teamFilter.teamIndex = ownerCharacterBody.teamComponent.teamIndex;
            teamFilter2.teamIndex = ownerCharacterBody.teamComponent.teamIndex;

            if(ownerBody.TryGetComponent(out GarrisonHolder garrisonHolder))
            {

               garrisonHolder.currentGarrison = this;
            } 
            else
            {
                Log.Warning("no GarrisonHolder");
            }
        }

        public void ShowGarrison(bool shouldShow)
        {
            model.Show(shouldShow);

            if (shouldShow)
            {
                if (Physics.Raycast(base.transform.position, Vector3.down, out RaycastHit raycastHit, 500f, LayerIndex.world.mask))
                {
                    base.transform.position = raycastHit.point;
                    base.transform.up = raycastHit.normal;
                }
            }
        }

        private void FixedUpdate()
        {
            if (!_hasLived)
            {
                _hasLived = healthComponent.alive;
                return;
            }

            if (ownershipComponent.ownerObject != null && _overlayController == null)
            {
                CreateHealthBarOverlay();
            }

            ////healthComponent.health -= (healthComponent.body.maxHealth / ConscriptConfig.M4_Garrison_Duration) * Time.fixedDeltaTime;

            //if (NetworkServer.active && healthComponent.alive)
            //{
            //    _takeDamageTim -= Time.fixedDeltaTime;
            //    if (_takeDamageTim > 0)
            //        return;

            //    if (_takeDamageTim < 0)
            //    {
            //        _takeDamageTim += _takeDamageInterval;
            //    }
            //    TakeDamage((healthComponent.body.maxHealth / ConscriptConfig.M4_Garrison_Duration) * _takeDamageInterval);

            //    //if (!healthComponent.alive)
            //    //{
            //    //    NetworkServer.DestroyObject(gameObject);
            //    //}
            //}
        }
        
        private void TakeDamage(float damage)
        {
            if (healthComponent && healthComponent.alive)
            {
                if (NetworkServer.active)
                {
                    DamageInfo damageInfo = new DamageInfo();
                    damageInfo.attacker = null;
                    damageInfo.inflictor = null;
                    damageInfo.position = transform.position;
                    damageInfo.crit = false;
                    damageInfo.damage = damage;
                    damageInfo.damageColorIndex = DamageColorIndex.Default;
                    damageInfo.damageType = DamageType.Silent;
                    damageInfo.force = Vector3.zero;
                    damageInfo.procCoefficient = 0f;
                    damageInfo.procChainMask = default(ProcChainMask);
                    healthComponent.TakeDamage(damageInfo);
                }
            }
        }

        private void CreateHealthBarOverlay()
        {
            _overlayController = HudOverlayManager.AddOverlay(ownershipComponent.ownerObject, new OverlayCreationParams
            {
                prefab = ConscriptAssets.GarrisonHealthBarPrefab,
                childLocatorEntry = "BottomLeftCluster"
            });

            _overlayController.onInstanceAdded += OverlayController_onInstanceAdded;
        }

        private void OverlayController_onInstanceAdded(OverlayController controller, GameObject instanceObject)
        {
            //todo ew
            instanceObject.GetComponentInChildren<HealthBar>().source = healthComponent;

            if (Input.GetKey(KeyCode.G))
            {
                instanceObject.transform.localPosition = Vector3.zero;
                instanceObject.transform.localRotation = Quaternion.identity;
                instanceObject.transform.localScale = Vector3.one;
            }
        }

        public void Die()
        {
            healthComponent.health = 0;
        }

        private void OnDestroy()
        {
            if (_overlayController != null)
            {
                _overlayController.onInstanceAdded -= OverlayController_onInstanceAdded;
                HudOverlayManager.RemoveOverlay(_overlayController);
            }
        }
    }
}
