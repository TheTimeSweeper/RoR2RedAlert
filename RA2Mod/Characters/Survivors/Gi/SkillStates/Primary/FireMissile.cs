using EntityStates;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace RA2Mod.Survivors.GI.SkillStates
{
    public class FireMissile : GenericProjectileBaseState
    {
        public static float BaseDuration => GIConfig.M1_Missile_Duration.Value;
        
        public static float DamageCoefficient => GIConfig.M1_Missile_Damage.Value;

        private Ray _fuckingAimRay;
        
        public override void OnEnter()
        {
            projectilePrefab = GIAssets.missilePrefab;
            //base.effectPrefab = Modules.Assets.SomeMuzzleEffect;
            //targetmuzzle = "muzzleThrow"

            attackSoundString = "Play_GuardienGIMissile";

            baseDuration = BaseDuration;
            baseDelayBeforeFiringProjectile = 0;

            damageCoefficient = DamageCoefficient;
            //proc coefficient is set on the components of the projectile prefab
            force = 80f;

            //base.projectilePitchBonus = 0;
            //base.minSpread = 0;
            //base.maxSpread = 0;

            //recoilAmplitude = 0.1f;
            bloom = 10;
            _fuckingAimRay = GetAimRay();

            base.OnEnter();

            PlayAnimation("Gesture, Override", "ShootGun", "ShootGun.playbackRate", duration);
        }

        public override void ModifyProjectileInfo(ref FireProjectileInfo fireProjectileInfo)
        {
            fireProjectileInfo.damageTypeOverride = DamageTypeCombo.GenericPrimary;
            fireProjectileInfo.rotation = Util.QuaternionSafeLookRotation(_fuckingAimRay.direction);
        }
    }
}