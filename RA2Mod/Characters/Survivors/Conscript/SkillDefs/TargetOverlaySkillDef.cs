using RoR2;
using RoR2.Skills;
using JetBrains.Annotations;
using UnityEngine;
using RoR2.HudOverlay;
using System;
using RA2Mod.Survivors.Conscript.Components;

namespace RA2Mod.Survivors.Conscript.SkillDefs
{
    public class TargetOverlaySkillDef : SkillDef
    {
        public GameObject hudOverlayPrefab;

        public override BaseSkillInstanceData OnAssigned([NotNull] GenericSkill skillSlot)
        {
            OverlayController overlayController = HudOverlayManager.AddOverlay(skillSlot.gameObject, new OverlayCreationParams
            {
                prefab = hudOverlayPrefab,
                childLocatorEntry = "ScopeContainer"
            });

            overlayController.onInstanceAdded += OverlayController_onInstanceAdded;
            overlayController.onInstanceRemove += OverlayController_onInstanceRemove;

            return new InstanceData { overlayController = overlayController };
        }

        private void OverlayController_onInstanceAdded(OverlayController overlayController, GameObject instanceObject)
        {
            TerrorDroneTrackerBody terrorDroneTrackerBody = overlayController.owner.target.GetComponent<TerrorDroneTrackerBody>();
            TerrorDroneTargetHudViewer terrorDroneTargetHudViewer = instanceObject.GetComponent<TerrorDroneTargetHudViewer>();
            terrorDroneTargetHudViewer.SubscribeToTrackerEvents(terrorDroneTrackerBody, true);
        }

        private void OverlayController_onInstanceRemove(OverlayController overlayController, GameObject instanceObject)
        {
            TerrorDroneTrackerBody terrorDroneTrackerBody = overlayController.owner.target.GetComponent<TerrorDroneTrackerBody>();
            TerrorDroneTargetHudViewer terrorDroneTargetHudViewer = instanceObject.GetComponent<TerrorDroneTargetHudViewer>();
            terrorDroneTargetHudViewer.SubscribeToTrackerEvents(terrorDroneTrackerBody, false);
        }

        public override void OnUnassigned([NotNull] GenericSkill skillSlot)
        {
            if (skillSlot.skillInstanceData is InstanceData instanceData)
            {
                instanceData.overlayController.onInstanceAdded -= OverlayController_onInstanceAdded;
                instanceData.overlayController.onInstanceRemove -= OverlayController_onInstanceRemove;

                HudOverlayManager.RemoveOverlay(instanceData.overlayController);
            }
        }

        protected class InstanceData : SkillDef.BaseSkillInstanceData
        {
            public OverlayController overlayController;
        }
    }
}
