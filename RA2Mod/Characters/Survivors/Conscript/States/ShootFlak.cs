using RA2Mod.Survivors.Conscript.States.TerrorDrone;
using RoR2;
using UnityEngine;

namespace RA2Mod.Survivors.Conscript.States
{
    public class ShootFlak : ShootConscriptGun
    {
        public override float TimedBaseDuration => ConscriptConfig.M1_Flak_Duration;
        public override float TimedBaseCastStartPercentTime => 1;

        public override float damageCoefficient => ConscriptConfig.M1_Flak_Damage;
        public float blastRadius => ConscriptConfig.M1_Flak_Radius;
        public override string fireSound => "Play_ConscriptFlakShoot";

        private GameObject ToTheStarsClassicEffectPrefab = LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/OmniEffect/OmniExplosionVFXQuick");


        protected override void ModifyBulletAttack(BulletAttack bulletAttack)
        {
            base.ModifyBulletAttack(bulletAttack);
            bulletAttack.hitCallback = FlakCallBack;
        }

        private bool FlakCallBack(BulletAttack bulletAttack, ref BulletAttack.BulletHit hitInfo)
        {
            EffectManager.SpawnEffect(ToTheStarsClassicEffectPrefab, new EffectData
            {
                origin = hitInfo.point,
                scale = blastRadius
            }, true);
            BlastAttack blastAttack = new BlastAttack
            {
                position = hitInfo.point,
                baseDamage = bulletAttack.damage,
                baseForce = 0f,
                radius = blastRadius,
                attacker = gameObject,
                inflictor = gameObject,
                teamIndex = TeamComponent.GetObjectTeam(gameObject),
                crit = bulletAttack.isCrit,
                procChainMask = bulletAttack.procChainMask,
                procCoefficient = bulletAttack.procCoefficient,
                damageColorIndex = bulletAttack.damageColorIndex,
                falloffModel = BlastAttack.FalloffModel.None,
                damageType = bulletAttack.damageType,
                //bonusForce = 2000f * Vector3.down
            };
            blastAttack.damageType.damageSource = DamageSource.Primary;
            blastAttack.Fire();

            JumpOnEnemy.CheckTerrorDroneHitAndExplode(damageStat, bulletAttack, ref hitInfo);

            bool result = false;
            if (hitInfo.collider)
            {
                result = ((1 << hitInfo.collider.gameObject.layer & bulletAttack.stopperMask) == 0);
            }
            return result;
        }
    }
}
