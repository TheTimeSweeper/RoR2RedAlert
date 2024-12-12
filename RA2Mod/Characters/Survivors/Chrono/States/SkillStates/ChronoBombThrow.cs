using EntityStates;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace RA2Mod.Survivors.Chrono.States
{
    public class ChronoBombThrow : GenericProjectileBaseState
    {
        public static float BaseDuration = 0.65f;

        public static float DamageCoefficient = ChronoConfig.M2_Bomb_Damage.Value;

        public override void OnEnter()
        {
            projectilePrefab = ChronoAssets.chronoBombProjectileThrown;
            //base.effectPrefab = Modules.Assets.SomeMuzzleEffect;
            //targetmuzzle = "muzzleThrow"

            attackSoundString = "";

            baseDuration = BaseDuration;
            baseDelayBeforeFiringProjectile = 0;

            damageCoefficient = DamageCoefficient;
            //proc coefficient is set on the components of the projectile prefab
            force = 80f;

            base.projectilePitchBonus = 0;
            //base.minSpread = 0;
            //base.maxSpread = 0;

            recoilAmplitude = 0.1f;
            bloom = 10;

            base.OnEnter();
        }

        public override Ray ModifyProjectileAimRay(Ray aimRay)
        {
            projectilePitchBonus *= 1 - Mathf.Max(0, Vector3.Dot(aimRay.direction.normalized, Vector3.up)) * 0.8f;
            return base.ModifyProjectileAimRay(aimRay);
        }

        public override void ModifyProjectileInfo(ref FireProjectileInfo fireProjectileInfo)
        {
            base.ModifyProjectileInfo(ref fireProjectileInfo);
            fireProjectileInfo.damageTypeOverride = DamageTypeCombo.GenericSecondary;
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Skill;
        }

        public override void PlayAnimation(float duration)
        {

            if (GetModelAnimator())
            {
                PlayAnimation("Gesture, Override", "ThrowBomb", "ThrowBomb.playbackRate", this.duration);
            }
        }
    }
}