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
        private TerrorDroneTrackerBody _viewerBody;

        public void Start()
        {
            _viewerBody = GetComponent<ProjectileController>().owner.GetComponent<TerrorDroneTrackerBody>();          
        }

        public void Add(HurtBox hurtBox)
        {
            _viewerBody.AddTarget(hurtBox);
        }
        
        public void Remove(HurtBox hurtBox)
        {
            _viewerBody.RemoveTarget(hurtBox);
        }
    }
}
