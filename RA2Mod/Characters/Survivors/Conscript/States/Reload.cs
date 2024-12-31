using EntityStates;
using RA2Mod.Modules.BaseStates;

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

        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return fixedAge > castStartTime ? InterruptPriority.Any : InterruptPriority.Skill;
        }
    }
}
