using RA2Mod.General.Components;
using RA2Mod.Survivors.Chrono.SkillDefs;
using RoR2;
using System.Collections.Generic;
using UnityEngine;

namespace RA2Mod.Survivors.Chrono.Components
{
    public class ChronoBombTeslaTracker : MonoBehaviour, ITracker
    {
        private TeslaTrackerComponent _trackerComponent;
        private HurtBox _trackingTarget;

        protected Indicator indicator;

        private Dictionary<GenericSkill, bool> skillMap = new Dictionary<GenericSkill, bool>();

        void Start()
        {
            _trackerComponent = GetComponent<TeslaTrackerComponent>();
            _trackerComponent.searchingForZap = true;
            _trackerComponent.SearchEvent += OnSearch;

            this.indicator = new Indicator(base.gameObject, ChronoAssets.chronoIndicatorIvan);

            GenericSkill[] skills = GetComponents<GenericSkill>();
            for (int i = 0; i < skills.Length; i++)
            {
                skillMap[skills[i]] = false;
                skills[i].onSkillChanged += OnSkillChanged;
                OnSkillChanged(skills[i]);
            }
        }

        void OnEnable()
        {
            if(_trackerComponent != null)
            {
                _trackerComponent.searchingForZap = true;
            }
            if (indicator != null)
            {
                indicator.active = true;
            }
        }

        void OnDisable()
        {
            if (_trackerComponent != null)
            {
                _trackerComponent.searchingForZap = false;
            }

            if (indicator != null)
            {
                indicator.active = false;
            }
        }

        private void OnSearch()
        {
            _trackingTarget = _trackerComponent.trackingTargetZap;
            if(_trackingTarget != null && _trackingTarget.hurtBoxGroup != null && _trackingTarget.hurtBoxGroup.mainHurtBox != null)
            {
                _trackingTarget = _trackingTarget.hurtBoxGroup.mainHurtBox;
            }

            indicator.targetTransform = _trackingTarget?.transform;
        }

        void OnDestroy()
        {
            _trackerComponent.SearchEvent -= OnSearch;
            foreach (GenericSkill skill in skillMap.Keys)
            {
                skill.onSkillChanged -= OnSkillChanged;
            }
        }

        protected virtual void OnSkillChanged(GenericSkill genericSkill)
        {
            skillMap[genericSkill] = genericSkill.skillDef is ChronoTrackerSkillDefBomb;

            CheckSkills();
        }

        private void CheckSkills()
        {
            foreach (bool isSkill in skillMap.Values)
            {
                if (isSkill)
                {
                    enabled = true;
                    return;
                }
            }

            enabled = false;
        }

        public HurtBox GetTrackingTarget()
        {
            return _trackingTarget;
        }
    }
}