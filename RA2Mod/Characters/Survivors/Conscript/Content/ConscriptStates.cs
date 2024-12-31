using RA2Mod.Survivors.Conscript.States;
using RA2Mod.Survivors.Conscript.States.TerrorDrone;

namespace RA2Mod.Survivors.Conscript
{
    public static class ConscriptStates
    {
        public static void Init()
        {
            Modules.Content.AddEntityState(typeof(JumpOnEnemy));

            Modules.Content.AddEntityState(typeof(BasicBitchBuff));
            Modules.Content.AddEntityState(typeof(FlakReload));
            Modules.Content.AddEntityState(typeof(HellMarch));
            Modules.Content.AddEntityState(typeof(HellMarchStompJump));
            Modules.Content.AddEntityState(typeof(HellMarchStompStomp));
            Modules.Content.AddEntityState(typeof(Reload));
            Modules.Content.AddEntityState(typeof(ReloadFast));
            Modules.Content.AddEntityState(typeof(ShootConscriptGun));
            Modules.Content.AddEntityState(typeof(ShootFlak));
            Modules.Content.AddEntityState(typeof(SpawnGarrison));
            Modules.Content.AddEntityState(typeof(ThrowMolotov));
            Modules.Content.AddEntityState(typeof(ThrowTerrorDrone));
        }
    }
}
