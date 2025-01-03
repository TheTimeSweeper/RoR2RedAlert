using RA2Mod.Modules.BaseStates;
using RA2Mod.Survivors.Conscript.Components;
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

        private EffectManagerHelper speedLinesEffect;

        public override void OnEnter()
        {
            base.OnEnter();

            if(gameObject.TryGetComponent(out GarrisonHolder holder))
            {
                holder.TryShowGarrison(false);
            }

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

            PlayAnimation("FullBody, Override", "ChargeReady", "Charge.playbackRate", castStartTime);

            characterBody.AddBuff(ConscriptBuffs.chargeBuff);

            aimAuraShit = cameraTargetParams.RequestAimType(CameraTargetParams.AimType.Aura);
        }

        protected override void OnCastEnter()
        {
            base.OnCastEnter();

            direction = GetFlatAimdirectionNormalized();

            speedLinesEffect = EffectManager.GetAndActivatePooledEffect(ConscriptAssets.RunSpeedEffect, GetModelTransform(), true);

            PlayAnimation("FullBody, Override", "ChargeCharge");
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
            if (success)
                return;

            success = true;
            EntityStateMachine.FindByCustomName(gameObject, "Weapon").SetState(new HellMarchStompJump { isCrit = isCrit, aimAuraShit = aimAuraShit, speedLinesEffect = speedLinesEffect });
            //don't end current state. hellmarchstopjump then hellmarchstompstomp will set this statemachine to main
        }

        public override void OnExit()
        {
            base.OnExit();

            PlayAnimation("FullBody, Override", "BufferEmpty");
            if (!success)
            {
                aimAuraShit.Dispose();
                characterBody.RemoveBuff(ConscriptBuffs.chargeBuff);

                if (speedLinesEffect != null && speedLinesEffect.OwningPool != null)
                {
                    speedLinesEffect.OwningPool.ReturnObject(speedLinesEffect);
                }

                if (gameObject.TryGetComponent(out GarrisonHolder holder))
                {
                    holder.TryShowGarrison(true);
                }
            }
        }
    }
}
