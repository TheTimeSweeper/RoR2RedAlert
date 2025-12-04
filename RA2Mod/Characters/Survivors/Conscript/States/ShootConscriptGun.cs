using EntityStates;
using RA2Mod.Modules.BaseStates;
using RA2Mod.Survivors.Conscript.States.TerrorDrone;
using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RA2Mod.Survivors.Conscript.States
{
    public class ShootConscriptGun : BaseTimedSkillState
    {
        public override float TimedBaseDuration => ConscriptConfig.M1_Gun_Duration.Value;
        public override float TimedBaseCastStartPercentTime => 1;

        public virtual float damageCoefficient => ConscriptConfig.M1_Gun_Damage.Value;
        public virtual string fireSound => "Play_ConscriptShoot";
        public static float procCoefficient = 1f;
        public static float force = 10f;
        public static float recoil = 0.2f;
        public static float range = ConscriptConfig.M1_Gun_Range;

        public static GameObject tracerEffectPrefab = EntityStates.Commando.CommandoWeapon.FirePistol2.tracerEffectPrefab;// ConscriptAssets.gunTracer;
        private string muzzleString;

        public override void OnEnter()
        {
            base.OnEnter();
            characterBody.SetAimTimer(2f);
            muzzleString = "GunMuzzle";
            
            PlayAnimation("Gesture, Override", "ShootGun", "ShootGun.playbackRate", duration);

            Fire();
        }

        protected void Fire()
        {
            characterBody.AddSpreadBloom(1.5f);
            EffectManager.SimpleMuzzleFlash(EntityStates.Commando.CommandoWeapon.FirePistol2.muzzleEffectPrefab, gameObject, muzzleString, false);
            Util.PlaySound(fireSound, gameObject);

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
                    damageType = DamageTypeCombo.GenericPrimary,
                    falloffModel = BulletAttack.FalloffModel.DefaultBullet,
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
                    radius = 0.75f,
                    sniper = false,
                    stopperMask = LayerIndex.CommonMasks.bullet,
                    weapon = null,
                    tracerEffectPrefab = tracerEffectPrefab,
                    spreadPitchScale = 0f,
                    spreadYawScale = 0f,
                    queryTriggerInteraction = QueryTriggerInteraction.UseGlobal,
                    hitEffectPrefab = EntityStates.Commando.CommandoWeapon.FirePistol2.hitEffectPrefab,
                    //modifyOutgoingDamageCallback = JumpOnEnemy.ModifyOutgoingDamageCallback
                    hitCallback = HitCallBack
                };
                bulletAttack.damageType.damageSource = DamageSource.Primary;
                ModifyBulletAttack(bulletAttack);
                bulletAttack.Fire();
            }
        }

        private bool HitCallBack(BulletAttack bulletAttack, ref BulletAttack.BulletHit hitInfo)
        {
            JumpOnEnemy.CheckTerrorDroneHitAndExplode(damageStat, bulletAttack, ref hitInfo);

            return BulletAttack.defaultHitCallback(bulletAttack, ref hitInfo);
        }

        protected virtual void ModifyBulletAttack(BulletAttack bulletAttack)
        {
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }
    }
}
