using HG;
using RoR2;
using RoR2.UI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RA2Mod.Survivors.Conscript.Components
{

    public class TerrorDroneTargetHudViewer : MonoBehaviour
    {
        // Token: 0x0400651A RID: 25882
        public GameObject visualizerPrefab;

        // Token: 0x0400651B RID: 25883
        public PointViewer pointViewer;

        // Token: 0x0400651D RID: 25885
        private Dictionary<HurtBox, GameObject> hurtBoxToVisualizer = new Dictionary<HurtBox, GameObject>();

        private TerrorDroneTrackerBody subscribedTrackerBody;

        //// Token: 0x060067E7 RID: 26599 RVA: 0x001B265A File Offset: 0x001B085A
        //private void Awake()
        //{
        //    //assigned in prefab
        //    this.pointViewer = base.GetComponent<PointViewer>();
        //}

        // Token: 0x060067E9 RID: 26601 RVA: 0x001B267C File Offset: 0x001B087C
        private void OnDisable()
        {
            foreach (KeyValuePair<HurtBox, GameObject> keyValuePair in this.hurtBoxToVisualizer)
            {
                this.pointViewer.RemoveElement(keyValuePair.Value);
            }
        }

        private void OnEnable()
        {
            foreach (KeyValuePair<HurtBox, GameObject> keyValuePair in this.hurtBoxToVisualizer)
            {
                this.pointViewer.AddElement(new PointViewer.AddElementRequest
                {
                    elementPrefab = this.visualizerPrefab,
                    target = keyValuePair.Key.transform,
                    targetWorldVerticalOffset = 0f,
                    targetWorldRadius = HurtBox.sniperTargetRadius,
                    scaleWithDistance = true
                });
            }
        }

        // Token: 0x060067EB RID: 26603 RVA: 0x001B2760 File Offset: 0x001B0960
        public void AddTarget(HurtBox hurtBox)
        {
            if (!this.hurtBoxToVisualizer.ContainsKey(hurtBox))
            {
                GameObject pointToView = this.pointViewer.AddElement(new PointViewer.AddElementRequest
                {
                    elementPrefab = this.visualizerPrefab,
                    target = hurtBox.transform,
                    targetWorldVerticalOffset = 0f,
                    targetWorldRadius = HurtBox.sniperTargetRadius,
                    scaleWithDistance = true
                });
                this.hurtBoxToVisualizer.Add(hurtBox, pointToView);
            }
        }

        public void RemoveTarget(HurtBox hurtBox)
        {
            if (this.hurtBoxToVisualizer.TryGetValue(hurtBox, out GameObject elementInstance))
            {
                this.pointViewer.RemoveElement(elementInstance);
                hurtBoxToVisualizer.Remove(hurtBox);
            }
        }

        public void SubscribeToTrackerEvents(TerrorDroneTrackerBody terrorDroneTrackerBody, bool shouldSubscribe)
        {
            if (terrorDroneTrackerBody == null)
                return;

            if (shouldSubscribe)
            {
                if (subscribedTrackerBody != null && terrorDroneTrackerBody == subscribedTrackerBody)
                    return;

                if(subscribedTrackerBody != null && terrorDroneTrackerBody != subscribedTrackerBody)
                {
                    UnsubscribeFromTracker(terrorDroneTrackerBody);
                }

                subscribedTrackerBody = terrorDroneTrackerBody;

                SubscribeToTracker(terrorDroneTrackerBody);
            }
            else
            {
                if (subscribedTrackerBody == null)
                    return;
                subscribedTrackerBody = null;

                UnsubscribeFromTracker(terrorDroneTrackerBody);
            }
        }

        private void SubscribeToTracker(TerrorDroneTrackerBody terrorDroneTrackerBody)
        {
            terrorDroneTrackerBody.OnAddTarget += AddTarget;
            terrorDroneTrackerBody.OnRemoveTarget += RemoveTarget;
        }

        private void UnsubscribeFromTracker(TerrorDroneTrackerBody terrorDroneTrackerBody)
        {
            terrorDroneTrackerBody.OnAddTarget -= AddTarget;
            terrorDroneTrackerBody.OnRemoveTarget -= RemoveTarget;
        }
    }
}
