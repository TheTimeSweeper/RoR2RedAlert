using RA2Mod.Survivors.Conscript.Components.Bundled;
using UnityEngine;

namespace RA2Mod.Survivors.Conscript.Components
{
    public class GarrisonHolder : MonoBehaviour
    {
        public GarrisonController garrisonController;

        public void TryShowGarrison(bool shouldShow)
        {
            if (garrisonController == null)
                return;

            if (shouldShow)
            {
                garrisonController.transform.position = transform.position + Vector3.up * 1;
            }

            garrisonController.ShowGarrison(shouldShow);

        }
    }
}
