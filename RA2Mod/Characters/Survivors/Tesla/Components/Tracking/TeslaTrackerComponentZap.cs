using RA2Mod.Survivors.Tesla;
using RA2Mod.Survivors.Tesla.SkillDefs;
using RoR2;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterBody))]
[RequireComponent(typeof(TeslaTrackerComponent))]
[RequireComponent(typeof(TeamComponent))]
public class TeslaTrackerComponentZap : MonoBehaviour {
    
    public static float nearTrackingDistance = 16;
    public static float mediumTrackingDistance = 28f;
    public float maxTrackingDistance => teslaTrackerComponent.maxTrackingDistance;

    public enum RangeTier {
        CLOSEST,
        MIDDLE,
        FURTHEST
    }

    public enum TargetType {
        DEFAULT,
        EMPOWERED,
        ALLY
    }

    private TeslaTrackerComponent teslaTrackerComponent;
    private CharacterBody characterBody;
    private TeamComponent teamComponent;
    //private InputBankTest inputBank;
    private TeslaTowerControllerController towerControllerComponent;

    private TeslaZapIndicator indicator;
    
    //private float trackerUpdateStopwatch;
    private HurtBox _trackingTarget;
    private RangeTier _trackingTargetDistance;

    private HealthComponent _towerTargetHealthComponent;
    private bool _targetingAlly;
    private bool _hasTowerNear;
    private bool _empowered;
    private bool _isZapping;

    void Awake() {
        indicator = new TeslaZapIndicator(base.gameObject, TeslaAssets.TeslaIndicatorPrefab);
        towerControllerComponent = GetComponent<TeslaTowerControllerController>();
    }
    
    protected virtual void Start() {
        teslaTrackerComponent = GetComponent<TeslaTrackerComponent>();
        teslaTrackerComponent.searchingForZap = true;
        characterBody = base.GetComponent<CharacterBody>();
        teamComponent = base.GetComponent<TeamComponent>();

        teslaTrackerComponent.SearchEvent += OnSearch;

        characterBody.skillLocator.primary.onSkillChanged += Primary_onSkillChanged;

        Primary_onSkillChanged(characterBody.skillLocator.primary);
    }

    void OnDestroy() {

        teslaTrackerComponent.SearchEvent -= OnSearch;
    }
        
    private void Primary_onSkillChanged(GenericSkill genericSkill) {

        _isZapping = genericSkill.skillDef is TeslaTrackingSkillDef;
    }

    #region access

    public HurtBox GetTowerTrackingTarget() {
        if (_targetingAlly)
            return null;
        if (!_hasTowerNear)
            return null;
        if (_trackingTarget == null)
            return null;
        if (_trackingTarget.hurtBoxGroup == null)
            return null;

        return _trackingTarget.hurtBoxGroup.mainHurtBox;
    }

    public HurtBox GetTrackingTarget() {
        return _trackingTarget;
    }

    public bool GetIsTargetingTeammate() {
        return _targetingAlly;
    }

    public RangeTier GetTrackingTargetDistance() => _trackingTargetDistance;

    #endregion access

    #region indicator

    public void SetTowerLockedTarget(HealthComponent healthComponent) {
        _towerTargetHealthComponent = healthComponent;
    }

    public void SetIndicatorEmpowered(bool empowered) {
        indicator.empowered = empowered;
        _empowered = empowered;
    }

    private void setIndicatorRange(RangeTier tier) {
        indicator.currentRange = tier;
    }
    private void setIndicatorAlly() {
        indicator.targetingAlly = _targetingAlly;
    }

    private void setIndicatorTower(bool hasTower) {
        indicator.towerIsTargeting = hasTower;
    }

    private void OnEnable() {
        indicator.active = true;
    }
    private void OnDisable() {
        indicator.active = false;
    }

    #endregion indicator

    private void FixedUpdate() {

        indicator.active = _isZapping || _empowered;
    }

    private void OnSearch() {
        HurtBox newTrackingTarget = teslaTrackerComponent.trackingTargetZap;

        //if (newTrackingTarget != null && _trackingTarget != null && newTrackingTarget.healthComponent == _trackingTarget.healthComponent)
        //{
        //    float dist = Vector3.Distance(newTrackingTarget.transform.position, _trackingTarget.transform.position);

        //    if (dist > 2 || CheckTrackingTargetDistance(newTrackingTarget) < _trackingTargetDistance)
        //    {
        //        _trackingTarget = newTrackingTarget;
        //    } 
        //    else
        //    {
        //        //keep old tracking target
        //    }
        //} 
        //else
        {
            _trackingTarget = newTrackingTarget;
        }

        setIsTargetingTeammate();
        
        if (_trackingTarget) {
            _trackingTargetDistance = CheckTrackingTargetDistance(_trackingTarget);
            setIndicatorRange(GetTrackingTargetDistance());
        }

        indicator.targetTransform = GetIndicatorTransform();
        
        if(TeslaConfig.M4_Tower_Targeting.Value)
            setIsTowerTargeting();
    }

    private Transform GetIndicatorTransform()
    {
        if (_trackingTarget == null)
            return null;

        if (_trackingTarget.hurtBoxGroup == null || _trackingTarget.hurtBoxGroup.mainHurtBox == null)
            return _trackingTarget.transform;

        Vector3 mainHurtboxPosition = _trackingTarget.hurtBoxGroup.mainHurtBox.transform.position;
        if(Vector3.Distance(mainHurtboxPosition, _trackingTarget.transform.position) < 3)
        {
            return _trackingTarget.hurtBoxGroup.mainHurtBox.transform;
        }

        return _trackingTarget.transform;         
    }

    protected virtual RangeTier CheckTrackingTargetDistance(HurtBox trackingTarget)
    {
        RangeTier range = RangeTier.FURTHEST;

        float dist = Vector3.Distance(trackingTarget.transform.position, transform.position);

        if (dist > mediumTrackingDistance)
        {
            range = RangeTier.FURTHEST;
        }
        if (dist < mediumTrackingDistance)
        {
            range = RangeTier.MIDDLE;
        }
        if (dist < nearTrackingDistance)
        {
            range = RangeTier.CLOSEST;
        }

        return range;
    }

    private void setIsTowerTargeting() {

        bool hasTarget = _towerTargetHealthComponent && _trackingTarget && _towerTargetHealthComponent == _trackingTarget.healthComponent;

        if (_towerTargetHealthComponent) {
            setIndicatorTower(hasTarget);
            return;
        }

        _hasTowerNear = towerControllerComponent.GetNearestTower();
        setIndicatorTower(_hasTowerNear);
    }

    private void setIsTargetingTeammate() {
        bool targetingFriendlyFire = false;
        if (_trackingTarget) {
            targetingFriendlyFire = !FriendlyFireManager.ShouldDirectHitProceed(_trackingTarget.healthComponent, teamComponent.teamIndex);// _trackingTarget.teamIndex == teamComponent.teamIndex;
        }
        
        _targetingAlly = targetingFriendlyFire;
        setIndicatorAlly();
    }

    public class TeslaZapIndicator : Indicator {

        public RangeTier currentRange = RangeTier.FURTHEST;

        public bool empowered;
        public bool targetingAlly;
        public bool towerIsTargeting;

        public TeslaZapIndicator(GameObject owner, GameObject visualizerPrefab) : base(owner, visualizerPrefab) { }

        public override void UpdateVisualizer() {
            base.UpdateVisualizer();

            if (visualizerTransform) {

                TeslaIndicatorView indicatorView = visualizerTransform.GetComponent<TeslaIndicatorView>();

                //color
                TargetType currentTarget = TargetType.DEFAULT;

                if (empowered) {
                    currentTarget = TargetType.EMPOWERED;
                } else if (targetingAlly) {
                    currentTarget = TargetType.ALLY;
                }

                indicatorView.SetColor((int)currentTarget);

                //sprite
                switch (currentTarget) {

                    default:
                    case TargetType.DEFAULT:
                        indicatorView.SetSpriteRange((int)currentRange);
                        break;
                    case TargetType.EMPOWERED:
                        indicatorView.SetSpriteTower();
                        break;
                    case TargetType.ALLY:
                        indicatorView.SetSpriteAlly();
                        break;
                }

                //tower indicator
                indicatorView.SetTowerIndicator(!targetingAlly && towerIsTargeting);
            }
        }
    }
}