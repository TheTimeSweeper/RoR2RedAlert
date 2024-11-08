using EntityStates;
using R2API;
using RA2Mod.Modules.BaseStates;
using RoR2;
using System;
using UnityEngine;

namespace RA2Mod.Survivors.Desolator.States
{
    public class RadBeam : BaseTimedSkillState
    {
        public override float TimedBaseDuration => BaseDuration * skillsPlusDurationMultiplier;
        public override float TimedBaseCastStartPercentTime => 1;

        public virtual float damageCoefficient => DamageCoefficient;
        public static float procCoefficient = 1f;
        public static float force = 100f;
        public static float recoil = 1f;
        public static float range = 4000f;

        public virtual float BaseDuration => 1.0f;
        public static float DamageCoefficient = 0.8f;

        public static int RadPrimaryStacks = 3;
        public static float RadDamageMultiplier = 0.6f;

        public float skillsPlusDurationMultiplier = 1;

        public static GameObject tracerEffectPrefab = DesolatorAssets.DesolatorTracerSnipe;

        public virtual string muzzleString => "MuzzleGauntlet";

        public override void OnEnter()
        {
            base.OnEnter();
            characterBody.SetAimTimer(2f);
            
            PlayShootAnimation();

            Fire();
        }

        protected virtual void PlayShootAnimation()
        {
            PlayAnimation("Desolator, Override", "DesolatorShoot");
        }

        protected void Fire()
        {
            characterBody.AddSpreadBloom(2000f);//uh
            EffectManager.SimpleMuzzleFlash(DesolatorAssets.DesolatorSmokeRing, gameObject, muzzleString, false);
            Util.PlaySound("Play_Desolator_Beam_Short", gameObject);

            if (isAuthority)
            {
                Ray aimRay = GetAimRay();
                AddRecoil(-1f * recoil, -2f * recoil, -0.5f * recoil, 0.5f * recoil);

                BulletAttack bulletAttack = new BulletAttack
                {
                    bulletCount = 1,
                    aimVector = aimRay.direction,
                    origin = aimRay.origin,
                    damage = damageCoefficient * damageStat,
                    damageColorIndex = DamageColorIndex.Default,
                    damageType = DamageType.Generic,
                    falloffModel = BulletAttack.FalloffModel.None,// ConscriptConfig.M1_Rifle_Falloff.Value ? BulletAttack.FalloffModel.DefaultBullet : BulletAttack.FalloffModel.None,
                    maxDistance = range,
                    force = force,
                    hitMask = LayerIndex.CommonMasks.bullet,
                    minSpread = 0f,
                    maxSpread = 0f,
                    isCrit = RollCrit(),
                    owner = gameObject,
                    muzzleName = muzzleString,
                    smartCollision = true,
                    procChainMask = default,
                    procCoefficient = procCoefficient,
                    radius = 1,
                    sniper = false,
                    stopperMask = LayerIndex.CommonMasks.bullet,
                    weapon = gameObject,
                    tracerEffectPrefab = tracerEffectPrefab,
                    spreadPitchScale = 0f,
                    spreadYawScale = 0f,
                    queryTriggerInteraction = QueryTriggerInteraction.UseGlobal,
                    hitEffectPrefab = DesolatorAssets.IrradiatedImpactEffect,
                };
                DamageAPI.AddModdedDamageType(bulletAttack, DesolatorDamageTypes.DesolatorDotPrimary);
                ModifyBulletAttack(bulletAttack);
                bulletAttack.Fire();
            }
        }

        protected virtual void ModifyBulletAttack(BulletAttack bulletAttack) { }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Skill;
        }
    }
}
