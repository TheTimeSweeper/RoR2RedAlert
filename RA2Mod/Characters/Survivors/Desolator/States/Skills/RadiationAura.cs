using EntityStates;
using RA2Mod.General;
using RA2Mod.Survivors.Desolator.Components;
using RoR2;
using UnityEngine.Networking;

namespace RA2Mod.Survivors.Desolator.States
{

    public class RadiationAura : BaseSkillState {

        public static float BuffDuration = 4f;
        public static float Radius = 40;

        public RoR2.CameraTargetParams.AimRequest aimRequest;

        private DesolatorAuraHolder _auraHolder;

        public override void OnEnter() {
            base.OnEnter();

            _auraHolder = GetComponent<DesolatorAuraHolder>();
            _auraHolder?.ActivateAura();

            Util.PlaySound(GeneralConfig.ClassicSounds ? "Play_Desolator_Deploy_High" : "Play_desolator_utilityLoop", gameObject);

            aimRequest = cameraTargetParams.RequestAimType(RoR2.CameraTargetParams.AimType.Aura);

            if (NetworkServer.active) {
                characterBody.AddTimedBuff(DesolatorBuffs.desolatorArmorBuff, BuffDuration);
            }
        }

        public override void FixedUpdate() {
            base.FixedUpdate();

            if (fixedAge > BuffDuration) {

                if (aimRequest != null)
                    aimRequest.Dispose();
                
                base.outer.SetNextStateToMain();
            }
        }

        public override void OnExit() {
            base.OnExit();
            Util.PlaySound("Stop_desolator_utilityLoop", gameObject);
            _auraHolder?.DeactivateAura();
        }
    }
}
