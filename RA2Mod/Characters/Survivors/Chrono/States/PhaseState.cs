using EntityStates;
using RA2Mod.Survivors.Chrono.Components;
using RoR2;
using UnityEngine;

namespace RA2Mod.Survivors.Chrono.States
{
    public class PhaseState : GenericCharacterMain {

        public float windDownTime = 0.5f;
        public PhaseIndicatorController controller;
        public float actionablePercentTime = ChronoConfig.debug_percentTimeUntilActionable.Value;
        private TemporaryOverlayInstance temporaryOverlay;
        private CharacterModel characterModel;
        private Ray aimRay;
        private bool _actionable;
        private Animator modelAnimator;

        public override void OnEnter() {
            base.OnEnter();
            Util.PlaySound("Play_ChronoMove", gameObject);
            characterBody.isSprinting = false;
            
            controller?.UpdateIndicatorActive(true);
            modelAnimator = GetModelAnimator();
            if (modelAnimator)
            {
                modelAnimator.enabled = false;
            }

            aimRay = GetAimRay();
            StartAimMode(aimRay, windDownTime * actionablePercentTime);

            if (characterDirection)
            {
                characterDirection.forward = aimRay.direction;
            }
            
            Transform modelTransform = base.GetModelTransform();
            if (modelTransform)
            {
                characterModel = modelTransform.GetComponent<CharacterModel>();
                if (characterModel)
                {
                    //characterModel.invisibilityCount++;
                    temporaryOverlay = TemporaryOverlayManager.AddOverlay(gameObject);
                    this.temporaryOverlay.duration = windDownTime;
                    this.temporaryOverlay.originalMaterial = ChronoAssets.frozenOverlayMaterial;
                    this.temporaryOverlay.AddToCharacterModel(characterModel);
                }
            }
        }

        public override void OnExit()
        {
            base.OnExit();

            controller?.UpdateIndicatorActive(false);
            if (modelAnimator)
            {
                modelAnimator.enabled = true;
                modelAnimator.speed = 1;
            }
            if (this.temporaryOverlay != null)
            {
                this.temporaryOverlay.Destroy();
            }

            //StartAimMode(1);

            //if (characterModel)
            //{
            //    characterModel.invisibilityCount--;
            //}
        }

        public override void FixedUpdate() {
            base.FixedUpdate();

            //if (characterDirection)
            //{
            //    characterDirection.forward = aimDirection;
            //}

            controller?.UpdateIndicatorFill((windDownTime - fixedAge) / windDownTime);

            if(!_actionable && fixedAge > windDownTime * actionablePercentTime)
            {
                _actionable = true;

                if (modelAnimator)
                {
                    modelAnimator.enabled = true;
                    modelAnimator.speed = 0.5f;
                }
                StartAimMode(1);
            }

            if (fixedAge > windDownTime) {
                outer.SetNextStateToMain();
            }
        }

        public override void HandleMovements()
        {
            return;
        }

        public override void UpdateAnimationParameters()
        {
            return;
        }

        public override bool CanExecuteSkill(GenericSkill skillSlot)
        {
            return _actionable;
        }

        public override InterruptPriority GetMinimumInterruptPriority() {
            return InterruptPriority.Frozen;
        }
    }
}