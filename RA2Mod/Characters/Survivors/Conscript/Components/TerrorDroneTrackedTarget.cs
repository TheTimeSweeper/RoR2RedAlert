using RoR2;
using RoR2.Projectile;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RA2Mod.Survivors.Conscript.Components
{
    public class TerrorDroneTrackedTarget : MonoBehaviour
    {
        public void Add(HurtBox hurtBox)
        {
            List<TerrorDroneTrackerBody> terrorDroneTrackerBodies = InstanceTracker.GetInstancesList<TerrorDroneTrackerBody>();
            for (int i = 0; i < terrorDroneTrackerBodies.Count; i++)
            {
                terrorDroneTrackerBodies[i].AddTarget(hurtBox);
            }
        }
        
        public void Remove(HurtBox hurtBox)
        {
            List<TerrorDroneTrackerBody> terrorDroneTrackerBodies = InstanceTracker.GetInstancesList<TerrorDroneTrackerBody>();
            for (int i = 0; i < terrorDroneTrackerBodies.Count; i++)
            {
                terrorDroneTrackerBodies[i].RemoveTarget(hurtBox);
            }
        }
    }
}
