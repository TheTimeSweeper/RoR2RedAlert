using EntityStates;
using EntityStates.Engi.SpiderMine;
using RA2Mod.General;
using RA2Mod.Survivors.Conscript.Components.Bundled;
using RoR2;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace RA2Mod.Survivors.Conscript.States.TerrorDrone
{
    public class JumpOnEnemy : BaseSpiderMineState
    {
        [SerializeField]
        public AnimationCurve yCurve;

        public float totalJumpTim = ConscriptConfig.M2_TerrorDrone_JumpTim;

        public override bool shouldStick => true;

        private Vector3 _initialPosition;
        private HurtBox _targetHurtbox;
        private bool _hasStucked;
        private float _fixedJumpTim;
        private float _updateJumpTim;
        private float _destroyTim;

        public override void OnEnter()
        {
            base.OnEnter();

            _initialPosition = transform.position;

            projectileStickOnImpact.ignoreWorld = true;

            if (isAuthority)
            {
                HurtBoxGroup targetHurtBoxGroup = null;

                if (projectileTargetComponent.target.TryGetComponent(out HurtBox hurtBox))
                {
                    targetHurtBoxGroup = hurtBox.hurtBoxGroup;
                }
                
                if (targetHurtBoxGroup != null)
                {
                    if (targetHurtBoxGroup.hurtBoxes.Length > 0)
                    {
                        _targetHurtbox = targetHurtBoxGroup.hurtBoxes[Random.Range(0, targetHurtBoxGroup.hurtBoxes.Length)];
                    }
                    else
                    {
                        Log.WarningDebug("_targetHurtBoxGroup.hurtBoxes.Length is 0");
                    }
                }
                else
                {
                    Log.WarningDebug("no _targetHurtBoxGroup");
                }
            }

            if(_targetHurtbox == null)
            {
                Log.WarningDebug("no _targetHurtbox");
                DetachAndEndState();
                return;
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (_targetHurtbox == null || rigidbody == null)
            {
                Log.WarningDebug("From fixedupdate");
                if (GeneralConfig.Debug.Value)
                {
                    Log.CheckNullAndWarn(nameof(_targetHurtbox), _targetHurtbox);
                    Log.CheckNullAndWarn(nameof(rigidbody), rigidbody);
                }
                DetachAndEndState();
                return;
            }
            _fixedJumpTim += Time.deltaTime;

            if (_hasStucked)
            {
                return;
            }

            FlyTowardTarget(_fixedJumpTim);

            if (projectileStickOnImpact.stuck)
            {
                if(!_hasStucked)
                {
                    _hasStucked = true;
                    GetStucked();
                }
            }
        }
        
        public override void Update()
        {
            if (!_hasStucked && _targetHurtbox != null)
            {
                _updateJumpTim += Time.deltaTime;
                FlyTowardTarget(_updateJumpTim);
            }
        }

        private void DetachAndEndState()
        {
            base.rigidbody.AddForce(Vector3.up, ForceMode.VelocityChange);
            projectileStickOnImpact.ignoreWorld = false;
            outer.SetNextState(new WaitForStick());
        }

        private void FlyTowardTarget(float t)
        {
            if(_targetHurtbox == null || rigidbody == null)
            {
                Log.WarningDebug("From flytwoardtarget");

                if (GeneralConfig.Debug.Value)
                {
                    Log.CheckNullAndWarn(nameof(_targetHurtbox), _targetHurtbox);
                    Log.CheckNullAndWarn(nameof(rigidbody), rigidbody);
                }
                DetachAndEndState();
                return;
            }

            Vector3 initialXZ = _initialPosition; initialXZ.y = 0;
            Vector3 targetXZ = _targetHurtbox.transform.position; targetXZ.y = 0;

            Vector3 position = Vector3.Lerp(initialXZ, targetXZ, t / totalJumpTim);
            position.y = Mathf.Lerp(_initialPosition.y, _targetHurtbox.transform.position.y, yCurve.Evaluate(t / totalJumpTim));
            base.rigidbody.MovePosition(position);
        }

        private void GetStucked()
        {
            if (isAuthority)
            {
                outer.SetNextState(new StickOnEnemy { targetHurtbox = _targetHurtbox });
            }
        }

        public static void CheckTerrorDroneHitAndExplode(BulletAttack bulletAttack, ref BulletAttack.BulletHit hitInfo)
        {
            if (ConscriptSurvivor.IsTerrorDroneTargetHit(ref hitInfo, out HurtBox weakHurtBox))
            {
                ExplodeAndScan(bulletAttack, weakHurtBox);
            }
        }

        private static void ExplodeAndScan(BulletAttack bulletAttack, HurtBox hitHurtBox)
        {
            hitHurtBox.damageModifier = HurtBox.DamageModifier.Normal;
            if (hitHurtBox.TryGetComponent(out TerrorDroneHurtBox resetModifier)){
                resetModifier.ResetModifier((HurtBox.DamageModifier)ConscriptSurvivor.TERROR_DRONE_HURTBOX);
            }
            
            Vector3 point = hitHurtBox.transform.position;

            float blastRadius = ConscriptConfig.M2_TerrorDrone_BlastRadius;
            EffectManager.SpawnEffect(ConscriptAssets.blastEffect, new EffectData
            {
                origin = point,
                scale = blastRadius
            }, true);
            BlastAttack blastAttack = new BlastAttack
            {
                position = point,
                baseDamage = bulletAttack.damage * ConscriptConfig.M2_TerrorDrone_BlastDamage,
                baseForce = 0f,
                radius = blastRadius,
                attacker = bulletAttack.owner,
                inflictor = bulletAttack.owner,
                teamIndex = TeamComponent.GetObjectTeam(bulletAttack.owner),
                crit = bulletAttack.isCrit,
                procChainMask = bulletAttack.procChainMask,
                procCoefficient = bulletAttack.procCoefficient,
                damageColorIndex = bulletAttack.damageColorIndex,
                falloffModel = BlastAttack.FalloffModel.None,
                damageType = bulletAttack.damageType,
                //bonusForce = 2000f * Vector3.down
            };
            blastAttack.damageType.damageSource = DamageSource.Primary | DamageSource.Secondary;
            blastAttack.Fire();

            Collider[] terrorScanColliders = Physics.OverlapSphere(point, blastRadius, LayerIndex.entityPrecise.mask);

            for (int i = 0; i < terrorScanColliders.Length; i++)
            {
                if (terrorScanColliders[i].TryGetComponent(out HurtBox hurtBox))
                {
                    if (hurtBox.damageModifier == (HurtBox.DamageModifier)ConscriptSurvivor.TERROR_DRONE_HURTBOX)
                    {
                        ExplodeAndScan(bulletAttack, hurtBox);
                    }
                }
            }
        }

        public override void OnSerialize(NetworkWriter writer)
        {
            base.OnSerialize(writer);
            writer.Write(HurtBoxReference.FromHurtBox(_targetHurtbox));
        }
        
        public override void OnDeserialize(NetworkReader reader)
        {
            base.OnDeserialize(reader);
            _targetHurtbox = reader.ReadHurtBoxReference().ResolveHurtBox();
        }
    }
}
