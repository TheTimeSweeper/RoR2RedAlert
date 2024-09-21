using RA2Mod.Survivors.Chrono.Components;
using RoR2;

namespace RA2Mod.Survivors.Chrono.States
{
    public class ChronoSprintStateEpic : ChronoSprintState
    {
        protected override float timeSpentMultiplier => 0;
        protected override float distMultiplier => 0;
        protected override ChronoProjectionMotor projectionPrefab => ChronoAssets.sprintProjectionPrefabScepter;
        protected override BuffDef briefBuff => RoR2Content.Buffs.HiddenInvincibility;
    }
}