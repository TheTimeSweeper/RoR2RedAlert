using RoR2;

namespace RA2Mod.Survivors.GI.SkillStates
{
    public class EnterBarricade : BaseEnterBarricade {
        protected override void OnEnterbarricade()
        {
            base.PlayAnimation("Fullbody, overried", "charge", "dash.playbackRate", duration);
            Util.PlaySound("Play_GIBarricade", gameObject);
            //spawn barricade or somethin
        }
    }
}