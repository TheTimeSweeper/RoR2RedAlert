using EntityStates;
using RA2Mod.Modules.BaseStates;
using RoR2;

namespace RA2Mod.Survivors.Conscript.States
{

    public class Reload : BaseTimedSkillState
    {
        public override float TimedBaseDuration => ConscriptConfig.M1_Gun_Reload;
        public override float TimedBaseCastStartPercentTime => 0.8f;

        public override void OnEnter()
        {
            base.OnEnter();

            PlayAnimation("Gesture, Override", "Reload", "reload.playbackRate", duration);
        }

        protected override void OnCastEnter()
        {
            base.OnCastEnter();

            while(activatorSkillSlot.stock < activatorSkillSlot.maxStock)
            {
                activatorSkillSlot.AddOneStock();
            }

            Util.PlaySound("Play_captain_m1_reload", gameObject);
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return fixedAge > castStartTime ? InterruptPriority.Any : InterruptPriority.Skill;
        }
    }
}
