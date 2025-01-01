using EntityStates;
using EntityStates.Engi.SpiderMine;
using RA2Mod.General;
using RA2Mod.Survivors.Conscript.Components.Bundled;
using RoR2;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.SendMouseEvents;

namespace RA2Mod.Survivors.Conscript.States.TerrorDrone
{
    public class JumpOnEnemy : BaseSpiderMineState
    {
        public static int debugCount;

        [SerializeField]
        public AnimationCurve yCurve;

        public float totalJumpTim = ConscriptConfig.M2_TerrorDrone_JumpTim;

        public override bool shouldStick => _hasStucked == false;

        private Vector3 _initialPosition;
        private HurtBox _targetHurtbox;
        private HurtBoxGroup _targetHurtBoxGroup;
        private bool _hasStucked;
        private float _fixedJumpTim;
        private float _updateJumpTim;
        private HurtBox _hurtBox;
        private float _destroyTim;

        public override void OnEnter()
        {
            base.OnEnter();

            if (projectileTargetComponent.target == null)
                return;

            _hurtBox = GetComponent<ChildLocator>().FindChild("HurtBox").GetComponent<HurtBox>();
            _initialPosition = transform.position;

            projectileStickOnImpact.ignoreWorld = true;

            if(projectileTargetComponent.target.TryGetComponent(out HurtBox hurtBox))
            {
                _targetHurtBoxGroup = hurtBox.hurtBoxGroup;
            }else
            {
                Log.WarningDebug("no hurtBox");
                DetachAndEndState();
                return;
            }

            if (_targetHurtBoxGroup != null)
            {
                if (_targetHurtBoxGroup.hurtBoxes.Length > 0)
                {
                    _targetHurtbox = _targetHurtBoxGroup.hurtBoxes[Random.Range(0, _targetHurtBoxGroup.hurtBoxes.Length)];
                }
                else
                {
                    Log.WarningDebug("_targetHurtBoxGroup.hurtBoxes.Length is 0");

                    DetachAndEndState();
                    return;
                }
            }
            else
            {
                Log.WarningDebug("no _targetHurtBoxGroup");

                DetachAndEndState();
                return;
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (_targetHurtbox == null || _targetHurtBoxGroup == null || rigidbody == null)
            {
                Log.WarningDebug("From fixedupdate");
                if (GeneralConfig.Debug.Value)
                {
                    Log.CheckNullAndWarn(nameof(_targetHurtbox), _targetHurtbox);
                    Log.CheckNullAndWarn(nameof(_targetHurtBoxGroup), _targetHurtBoxGroup);
                    Log.CheckNullAndWarn(nameof(rigidbody), rigidbody);
                }
                DetachAndEndState();
                return;
            }
            _fixedJumpTim += Time.deltaTime;

            if (_hasStucked)
            {
                //_destroyTim += Time.deltaTime;

                //if(_destroyTim > 20)
                //{
                //    Destroy(gameObject);
                //}
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
            if (!_hasStucked || projectileTargetComponent.target == null)
            {
                _updateJumpTim += Time.deltaTime;
                FlyTowardTarget(_updateJumpTim);
            }
        }

        private void DetachAndEndState()
        {
            base.rigidbody.AddForce(Vector3.up, ForceMode.VelocityChange);
            outer.SetNextState(new WaitForStick());
        }

        private void FlyTowardTarget(float t)
        {
            if(_targetHurtbox == null || _targetHurtBoxGroup == null || rigidbody == null)
            {
                Log.WarningDebug("From flytwoardtarget");

                if (GeneralConfig.Debug.Value)
                {
                    Log.CheckNullAndWarn(nameof(_targetHurtbox), _targetHurtbox);
                    Log.CheckNullAndWarn(nameof(_targetHurtBoxGroup), _targetHurtBoxGroup);
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
            _targetHurtBoxGroup.hurtBoxes = _targetHurtBoxGroup.hurtBoxes.Append(_hurtBox).ToArray();
            _hurtBox.healthComponent = _targetHurtbox.healthComponent;
            _targetHurtBoxGroup.OnValidate();
            //_hurtBox.hurtBoxGroup = _targetHurtbox.hurtBoxGroup;
            _hurtBox.gameObject.SetActive(true);
            gameObject.name += debugCount;
            debugCount++;
            GetComponent<DestroyOnTimer>().enabled = true;


            base.FindModelChild("PreDetonate")?.gameObject.SetActive(false);
        }

        public override void OnExit()
        {
            base.OnExit();
            Log.WarningDebug($"exiting {gameObject.name}, outer.destroying {outer.destroying}");
            ReturnTheNaturalOrder();
        }

        private void ReturnTheNaturalOrder()
        {
            if (_targetHurtBoxGroup)
            {
                //sorry for linq just lazy
                List<HurtBox> list = _targetHurtBoxGroup.hurtBoxes.ToList();
                if (list.Contains(_hurtBox))
                {
                    list.Remove(_hurtBox);
                }
                _targetHurtBoxGroup.hurtBoxes = list.ToArray();
                _targetHurtBoxGroup.OnValidate();
                _targetHurtBoxGroup = null;
            }
            if (_hurtBox != null)
            {
                _hurtBox.gameObject.SetActive(false);
                _hurtBox.healthComponent = null;
            }

            projectileStickOnImpact.ignoreWorld = false;
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
    }
}
