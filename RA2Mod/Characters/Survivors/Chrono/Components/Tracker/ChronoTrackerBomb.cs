using RA2Mod.General.Components;
using RA2Mod.Survivors.Chrono.SkillDefs;
using RoR2;
using System.Collections.Generic;
using UnityEngine;

namespace RA2Mod.Survivors.Chrono.Components
{
    public class ChronoBombTeslaTracker : MonoBehaviour
    {
        private TeslaTrackerComponent _trackerComponent;

        private Dictionary<GenericSkill, bool> skillMap = new Dictionary<GenericSkill, bool>();

        void Start()
        {
            GenericSkill[] skills = GetComponents<GenericSkill>();
            for (int i = 0; i < skills.Length; i++)
            {
                skillMap[skills[i]] = false;
                skills[i].onSkillChanged += OnSkillChanged;
                OnSkillChanged(skills[i]);
            }
        }

        void OnDestroy()
        {
            foreach (GenericSkill skill in skillMap.Keys)
            {
                skill.onSkillChanged -= OnSkillChanged;
            }
        }

        protected virtual void OnSkillChanged(GenericSkill genericSkill)
        {
            skillMap[genericSkill] = genericSkill.skillDef is T;

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
    }

    public class ChronoTrackerBomb : TrackerSkillDefRequired<ChronoTrackerSkillDefBomb>
    {
        public override float maxTrackingDistance => 12;

        public override float maxTrackingAngle => 180;

        public override BullseyeSearch.SortMode bullseyeSortMode => BullseyeSearch.SortMode.Angle;

        public override bool filterByLoS => false;

        private CameraTargetParams cameraTargetParams;

        private SkillLocator skillLocator;

        protected override void Awake()
        {
            cameraTargetParams = GetComponent<CameraTargetParams>();
            this.indicator = new Indicator(base.gameObject, ChronoAssets.chronoIndicatorIvan);

            skillLocator = GetComponent<SkillLocator>();
        }

        protected override HurtBox SearchForTarget(Ray aimRay)
        {
            //if (cameraTargetParams)
            //{
            //    aimRay.origin = cameraTargetParams.cameraPivotTransform.position;
            //}
            
            return base.SearchForTarget(aimRay);
        }
        
        protected override TeamMask GetTeamMask()
        {
            return TeamMask.all;
        }
    }
}