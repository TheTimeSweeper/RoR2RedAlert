using RA2Mod;
using RA2Mod.Survivors.Tesla;
using RoR2;
using System;
using UnityEngine;

[RequireComponent(typeof(CharacterBody))]
[RequireComponent(typeof(TeslaTrackerComponent))]
[RequireComponent(typeof(TeamComponent))]
public class TeslaTrackerComponentDash : MonoBehaviour {

    private TeslaDashIndicator indicator;

    private TeslaTrackerComponent teslaTrackerComponent;
    private CharacterBody characterBody;
    private TeamComponent teamComponent;

    private HurtBox _trackingTarget;
    private bool _targetingAlly;

    private bool _isDashing;
    private bool _isSkillReady;

    private bool _active;
    private bool active
    {
        get
        {
            return _active;
        }
        set
        {
            if (_active == value)
                return;
            Log.Warning($"trackerdash active {_active}");
            _active = value;
            indicator.active = value;
            teslaTrackerComponent.searchingForDash = value;
        }
    }

    void Awake() {
        indicator = new TeslaDashIndicator(base.gameObject, TeslaAssets.TeslaIndicatorPrefabDash);
    }

    void Start() {
        teslaTrackerComponent = GetComponent<TeslaTrackerComponent>();
        teslaTrackerComponent.searchingForDash = true;
        characterBody = base.GetComponent<CharacterBody>();
        //inputBank = base.GetComponent<InputBankTest>();
        teamComponent = base.GetComponent<TeamComponent>();

        teslaTrackerComponent.SearchEvent += OnSearch;

        characterBody.skillLocator.utility.onSkillChanged += Utility_onSkillChanged;

        Utility_onSkillChanged(characterBody.skillLocator.utility);
    }

    void OnDestroy() {

        teslaTrackerComponent.SearchEvent -= OnSearch;
    }

    private void Utility_onSkillChanged(GenericSkill genericSkill) {

        _isDashing = genericSkill.skillDef.skillNameToken == TeslaTrooperSurvivor.TOKEN_PREFIX + "UTILITY_BLINK_NAME";
    }

    private void FixedUpdate() {

        active = _isDashing && _isSkillReady;
    }

    #region access

    public HurtBox GetTrackingTarget() {
        return _trackingTarget;
    }

    public bool GetIsTargetingTeammate() {
        return _targetingAlly;
    }

    #endregion access

    public void SetIsSkillReady(bool ready) {
        _isSkillReady = ready;
    }

    private void OnSearch() {

        _trackingTarget = teslaTrackerComponent.trackingTargetDash;

        setIsTargetingTeammate();

        indicator.targetTransform = GetIndicatorTransform();
    }

    private Transform GetIndicatorTransform()
    {
        if (_trackingTarget == null)
            return null;

        if (_trackingTarget.hurtBoxGroup == null || _trackingTarget.hurtBoxGroup.mainHurtBox == null)
            return _trackingTarget.transform;

        Vector3 mainHurtboxPosition = _trackingTarget.hurtBoxGroup.mainHurtBox.transform.position;
        if (Vector3.Distance(mainHurtboxPosition, _trackingTarget.transform.position) < 3)
        {
            return _trackingTarget.hurtBoxGroup.mainHurtBox.transform;
        }

        return _trackingTarget.transform;
    }

    private void setIsTargetingTeammate() {
        bool targetingFriendlyFire = false;
        if (_trackingTarget) {
            targetingFriendlyFire = !FriendlyFireManager.ShouldDirectHitProceed(_trackingTarget.healthComponent, teamComponent.teamIndex);
        }

        _targetingAlly = targetingFriendlyFire;
    }


    public class TeslaDashIndicator : Indicator {

        public TeslaDashIndicator(GameObject owner, GameObject visualizerPrefab) : base(owner, visualizerPrefab) { }
    }
}
