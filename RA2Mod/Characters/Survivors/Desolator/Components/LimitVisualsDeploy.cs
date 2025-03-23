using RA2Mod.General.Components;

namespace RA2Mod.Survivors.Desolator.Components
{
    public class LimitVisualsDeploy : LimitObjectsOfType<LimitVisualsDeploy>
    {
        public override int limit => DesolatorConfig.VisualsLimit;
    }
}
