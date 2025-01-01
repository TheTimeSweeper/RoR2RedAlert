using RoR2;
using UnityEngine;

namespace RA2Mod.Survivors.Conscript.Components
{
    public class TerrorDroneTrackerBody : MonoBehaviour
    {
        public delegate void AddTargetEvent(HurtBox hurtBox);
        public event AddTargetEvent OnAddTarget;
        
        public delegate void RemoveTargetEvent(HurtBox hurtBox);
        public event RemoveTargetEvent OnRemoveTarget;

        internal void AddTarget(HurtBox hurtBox)
        {
            OnAddTarget?.Invoke(hurtBox);
        }

        internal void RemoveTarget(HurtBox hurtBox)
        {
            OnRemoveTarget?.Invoke(hurtBox);
        }
    }
}
