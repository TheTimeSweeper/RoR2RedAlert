using RoR2;
using RoR2.Skills;
using JetBrains.Annotations;
using UnityEngine;
using RoR2.HudOverlay;

namespace RA2Mod.Survivors.Conscript.SkillDefs
{
    public class TargetOverlaySkillDef : SkillDef
    {
        public GameObject hudOverlayPrefab;

        public override BaseSkillInstanceData OnAssigned([NotNull] GenericSkill skillSlot)
        {
            return new InstanceData(HudOverlayManager.AddOverlay(skillSlot.gameObject, new OverlayCreationParams
            {
                prefab = hudOverlayPrefab,
                childLocatorEntry = "ScopeContainer"
            }));
        }

        public override void OnUnassigned([NotNull] GenericSkill skillSlot)
        {
            if (skillSlot.skillInstanceData is InstanceData instanceData)
            {
                HudOverlayManager.RemoveOverlay(instanceData.overlayController);
            }
        }

        protected class InstanceData : SkillDef.BaseSkillInstanceData
        {
            public OverlayController overlayController;

            public InstanceData(OverlayController overlayController)
            {
                this.overlayController = overlayController;
            }
        }
    }
}
