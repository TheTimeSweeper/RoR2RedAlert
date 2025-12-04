using EntityStates.Engi.SpiderMine;
using RA2Mod.Survivors.Conscript.Components.Bundled;
using RoR2;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace RA2Mod.Survivors.Conscript.States.TerrorDrone
{
    public class StickOnEnemy : BaseSpiderMineState
    {
        public override bool shouldStick => true;

        public HurtBox targetHurtbox;
        private HurtBox _hurtBox;

        public override void OnEnter()
        {
            base.OnEnter();

            _hurtBox = GetComponent<ChildLocator>().FindChild("HurtBox").GetComponent<HurtBox>();

            targetHurtbox.hurtBoxGroup.hurtBoxes = targetHurtbox.hurtBoxGroup.hurtBoxes.Append(_hurtBox).ToArray();
            _hurtBox.healthComponent = targetHurtbox.healthComponent;
            targetHurtbox.hurtBoxGroup.OnValidate();
            _hurtBox.gameObject.SetActive(true);
            _hurtBox.damageModifier = (HurtBox.DamageModifier)ConscriptSurvivor.TERROR_DRONE_HURTBOX;
            GetComponent<DestroyOnTimer>().enabled = true;

            //shut up the beeping
            base.FindModelChild("PreDetonate")?.gameObject.SetActive(false);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if(targetHurtbox == null || targetHurtbox.healthComponent == null || targetHurtbox.healthComponent.alive == false)
            {
                DetachAndEndState();
            }
        }

        private void DetachAndEndState()
        {
            base.rigidbody.AddForce(Vector3.up, ForceMode.VelocityChange);
            outer.SetNextState(new WaitForStick());
        }

        public override void OnExit()
        {
            base.OnExit();

            ReturnTheNaturalOrder();
        }

        private void ReturnTheNaturalOrder()
        {
            if (targetHurtbox && targetHurtbox.hurtBoxGroup)
            {
                //sorry for linq just lazy
                List<HurtBox> list = targetHurtbox.hurtBoxGroup.hurtBoxes.ToList();
                if (list.Contains(_hurtBox))
                {
                    list.Remove(_hurtBox);
                }
                targetHurtbox.hurtBoxGroup.hurtBoxes = list.ToArray();
                targetHurtbox.hurtBoxGroup.OnValidate();
            }
            if (_hurtBox != null)
            {
                _hurtBox.gameObject.SetActive(false);
                _hurtBox.healthComponent = null;
            }

            projectileStickOnImpact.ignoreWorld = false;
            if (NetworkServer.active)
            {
                projectileStickOnImpact.Detach();
            }
        }

        public override void OnSerialize(NetworkWriter writer)
        {
            base.OnSerialize(writer);
            writer.Write(HurtBoxReference.FromHurtBox(targetHurtbox));
        }

        public override void OnDeserialize(NetworkReader reader)
        {
            base.OnDeserialize(reader);
            targetHurtbox = reader.ReadHurtBoxReference().ResolveHurtBox();
        }
    }
}
