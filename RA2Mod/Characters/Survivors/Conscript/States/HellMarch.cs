using RA2Mod.Modules.BaseStates;
using RoR2;
using System;
using System.Collections.Generic;
using UnityEngine;
using static RoR2.BlastAttack;

namespace RA2Mod.Survivors.Conscript.States
{
    public class HellMarch : BaseTimedSkillState
    {
        public override float TimedBaseDuration => ConscriptConfig.M3_March_Duration;
        public override float TimedBaseCastStartPercentTime => ConscriptConfig.M3_March_Windup;


        protected OverlapAttack overlapAttack;
        protected Vector3 direction;

        private CameraTargetParams.AimRequest aimAuraShit;
        private bool isCrit;
        private bool success;

        public override void OnEnter()
        {
            base.OnEnter();

            overlapAttack = new OverlapAttack();
            overlapAttack.damageType = DamageType.Stun1s;
            overlapAttack.damageType.damageSource = DamageSource.Utility;
            overlapAttack.attacker = gameObject;
            overlapAttack.inflictor = gameObject;
            overlapAttack.teamIndex = GetTeam();
            overlapAttack.damage = ConscriptConfig.M3_March_ChargeDamage * damageStat;
            overlapAttack.procCoefficient = 1;
            //overlapAttack.hitEffectPrefab = hitEffectPrefab;
            //overlapAttack.forceVector = bonusForce;
            //overlapAttack.pushAwayForce = pushForce;
            overlapAttack.hitBoxGroup = FindHitBoxGroup("chargeHitBox");
            isCrit = RollCrit();
            overlapAttack.isCrit = isCrit;
            //overlapAttack.impactSound = impactSound;

            PlayAnimation("Fullbody, overried", "charge", "dash.playbackRate", castStartTime);

            characterBody.AddBuff(ConscriptBuffs.chargeBuff);

            aimAuraShit = cameraTargetParams.RequestAimType(CameraTargetParams.AimType.Aura);
        }

        protected override void OnCastEnter()
        {
            base.OnCastEnter();

            direction = GetFlatAimdirectionNormalized();

            PlayAnimation("Fullbody, overried", "DashContinuous");
        }

        private Vector3 GetFlatAimdirectionNormalized()
        {
            Vector3 direction = GetAimRay().direction;
            direction.y = 0;
            direction = direction.normalized;
            return direction;
        }

        protected override void OnCastFixedUpdate()
        {
            base.OnCastFixedUpdate();

            List<HurtBox> hitresults = new List<HurtBox>();
            if (overlapAttack.Fire(hitresults))
            {
                for (int i = 0; i < hitresults.Count; i++) 
                {
                    Modules.Utils.Knockup(hitresults[i].healthComponent.body, ConscriptConfig.M3_March_KnockUp, false, true);
                }
            }

            UpdateDirection();

            base.characterMotor.moveDirection = direction;
            characterDirection.forward = direction;

            if (inputBank.skill3.justPressed)
            {
                SetNextState();
            }
        }

        protected virtual void UpdateDirection()
        {
            //perpendicular to current move direction
            Vector3 crossMoveDirection = -Vector3.Cross(Vector3.up, direction);
            //left and right input direction relative to aim (a.k.a regardless of move)
            Vector3 crossAimDirection = -Vector3.Cross(Vector3.up, GetFlatAimdirectionNormalized());
            direction += Vector3.Dot(crossAimDirection, inputBank.moveVector) * crossMoveDirection * ConscriptConfig.M3_March_TurnInfluence * GetDeltaTime();
        }

        protected override void SetNextState()
        {
            success = true;
            outer.SetState(new HellMarchStompJump { isCrit = isCrit, aimAuraShit = aimAuraShit });
        }

        public override void OnExit()
        {
            base.OnExit();

            PlayAnimation("Fullbody, overried", "BufferEmpty");
            if (!success)
            {
                aimAuraShit.Dispose();
                characterBody.RemoveBuff(ConscriptBuffs.chargeBuff);
            }
        }
    }
}
