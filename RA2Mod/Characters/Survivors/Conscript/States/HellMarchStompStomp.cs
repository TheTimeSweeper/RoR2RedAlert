﻿using EntityStates;
using RA2Mod.Modules.BaseStates;
using RoR2;
using UnityEngine;

namespace RA2Mod.Survivors.Conscript.States
{
    public class HellMarchStompStomp : BaseTimedSkillState
    {
        public override float TimedBaseDuration => 0.3f;
        public override float TimedBaseCastStartPercentTime => 0;

        public bool isCrit;
        public CameraTargetParams.AimRequest aimAuraShit;
        
        private Vector3 blastPosition;

        public override void OnEnter()
        {
            base.OnEnter();

            PlayAnimation("Arms, Override", "jumpSwingLand");

            //non-authority gets it in deserialize
            if (isAuthority)
            {
                blastPosition = transform.position;
                BigBlast();//delete if knockup isnt networked
            }
            //uncomment if knockup isnt networked
            //if (NetworkServer.active)
            //{
            //    BigBlast();
            //}
        }

        protected override void OnCastFixedUpdate()
        {
            base.OnCastFixedUpdate();

            characterMotor.velocity = Vector3.zero;
        }

        //uncomment if knockup isnt networked
        //public override void OnSerialize(NetworkWriter writer)
        //{
        //    base.OnSerialize(writer);
        //    writer.Write(blastPosition);
        //}
        //public override void OnDeserialize(NetworkReader reader)
        //{
        //    base.OnDeserialize(reader);
        //    blastPosition = reader.ReadVector3();
        //}

        private void BigBlast()
        {
            BlastAttack blast = new BlastAttack
            {
                attacker = gameObject,
                inflictor = gameObject,
                teamIndex = teamComponent.teamIndex,
                //attackerFiltering = AttackerFiltering.NeverHit

                position = blastPosition,
                radius = ConscriptConfig.M3_March_StompRadius,
                falloffModel = BlastAttack.FalloffModel.None,

                baseDamage = damageStat * ConscriptConfig.M3_March_StompDamage,
                crit = isCrit,
                //damageColorIndex = DamageColorIndex.Default,

                procCoefficient = 1,
                //procChainMask = 
                //losType = BlastAttack.LoSType.NearestHit,

                //impactEffect = EffectIndex.uh;
            };
            blast.damageType = DamageType.Stun1s;
            blast.damageType.damageSource = DamageSource.Utility;
            BlastAttack.Result result = blast.Fire();
            for (int i = 0; i < result.hitCount; i++)
            {
                Modules.Utils.Knockup(result.hitPoints[i].hurtBox.healthComponent.body, ConscriptConfig.M3_March_KnockUp, false, true);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            aimAuraShit.Dispose();
            if (characterBody.HasBuff(ConscriptBuffs.chargeBuff))
            {
                characterBody.RemoveBuff(ConscriptBuffs.chargeBuff);
            }
            if (characterBody.HasBuff(JunkContent.Buffs.IgnoreFallDamage))
            {
                characterBody.RemoveBuff(JunkContent.Buffs.IgnoreFallDamage);
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }
    }
}