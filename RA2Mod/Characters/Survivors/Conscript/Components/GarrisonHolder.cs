using RA2Mod.Survivors.Conscript.Components.Bundled;
using UnityEngine;

namespace RA2Mod.Survivors.Conscript.Components
{
    public class GarrisonHolder : MonoBehaviour
    {
        public GarrisonController currentGarrison;

        public void TryShowGarrison(bool shouldShow)
        {
            if (currentGarrison == null)
                return;

            if (shouldShow)
            {
                currentGarrison.transform.position = transform.position + Vector3.up * 1;
            }

            currentGarrison.ShowGarrison(shouldShow);
        }
    }
}
