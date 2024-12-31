using RoR2;
using UnityEngine;
using System.Collections.Generic;

namespace RA2Mod.Survivors.Conscript.Components.Bundled
{
    public class TerrorDroneHurtBox : MonoBehaviour
    {
        public static IReadOnlyList<HurtBox> readOnlyTerrorDroneHurtBoxList => terrorDroneHurtBoxList;
        private static readonly List<HurtBox> terrorDroneHurtBoxList = new List<HurtBox>();

        [SerializeField]
        private HurtBox hurtBox;

        [SerializeField]
        private float setTime = 3;

        private bool boxAdded;
        private HurtBox.DamageModifier _modifierToSet;
        private float _tim;

        void OnEnable()
        {
            AddBox(true);
        }

        private void AddBox(bool shouldAdd)
        {
            if (boxAdded == shouldAdd)
                return;
            boxAdded = shouldAdd;

            if (shouldAdd)
            {
                terrorDroneHurtBoxList.Add(hurtBox);
            }
            else
            {
                terrorDroneHurtBoxList.Remove(hurtBox);
            }
        }

        void OnDisable()
        {
            AddBox(false);
        }

        public void ResetModifier(HurtBox.DamageModifier modifierToSet_)
        {
            AddBox(false);
            _modifierToSet = modifierToSet_;
            _tim = setTime;
        }

        void FixedUpdate()
        {
            if (_tim > 0)
            {
                _tim -= Time.fixedDeltaTime;
                if (_tim <= 0)
                {
                    hurtBox.damageModifier = _modifierToSet;
                    AddBox(true);
                }
            }
        }
    }
}
