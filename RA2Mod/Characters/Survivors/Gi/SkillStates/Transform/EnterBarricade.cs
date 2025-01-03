using RoR2;

namespace RA2Mod.Survivors.GI.SkillStates
{
    public class EnterBarricade : BaseEnterBarricade {
        protected override void OnEnterbarricade()
        {
            base.PlayAnimation("FullBody, Underride", "ChargeReady", "Charge.playbackRate", duration);
            Util.PlaySound("Play_GIBarricade", gameObject);
            //spawn barricade or somethin
        }
    }
}