using EntityStates;
using RA2Mod.Survivors.Conscript.Components;
using RobDriver.Modules;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace RA2Mod.Survivors.Conscript.States
{
    public class HellMarchStompJump : BaseSkillState
    {
        public bool isCrit;
        public CameraTargetParams.AimRequest aimAuraShit;
        public EffectManagerHelper speedLinesEffect;

        private bool success;
        private bool hasLeftGround;

        public override void OnEnter()
        {
            base.OnEnter();

            characterMotor.Motor.ForceUnground();
            SmallHop(characterMotor, ConscriptConfig.M3_March_Hop);
            PlayAnimation("FullBody, Override", "ChargeJump");

            characterBody.AddBuff(JunkContent.Buffs.IgnoreFallDamage);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (!characterMotor.isGrounded)
            {
                hasLeftGround = true;
            }
            characterDirection.forward = characterMotor.velocity;

            ref float ySpeed = ref characterMotor.velocity.y;            //increase gravity a bit less on the rise but still increase gravity
            ySpeed += Physics.gravity.y * GetDeltaTime() * (ySpeed > 0 ? ConscriptConfig.M3_March_GravityUp : ConscriptConfig.M3_March_GravityDown);

            if (isAuthority && isGrounded && hasLeftGround)
            {
                success = true;
                outer.SetNextState(new HellMarchStompStomp { isCrit = isCrit, aimAuraShit = aimAuraShit });
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            if (!success)
            {
                aimAuraShit.Dispose();
                if (characterBody.HasBuff(ConscriptBuffs.chargeBuff))
                {
                    characterBody.RemoveBuff(ConscriptBuffs.chargeBuff);
                }
                characterBody.RemoveBuff(JunkContent.Buffs.IgnoreFallDamage);

                PlayAnimation("FullBody, Override", "BufferEmpty");


                if (gameObject.TryGetComponent(out GarrisonHolder holder))
                {
                    holder.TryShowGarrison(true);
                }
            }

            EntityStateMachine.FindByCustomName(gameObject, "Body").SetNextStateToMain();

            if (speedLinesEffect != null && speedLinesEffect.OwningPool != null)
            {
                speedLinesEffect.OwningPool.ReturnObject(speedLinesEffect);
            }
        }
    }
}
