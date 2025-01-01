using RoR2;
using UnityEngine;

namespace RA2Mod.Survivors.Conscript.Components.Bundled
{
    public class GarrisonModel : MonoBehaviour
    {
        [SerializeField]
        private ObjectScaleCurve deactivateScaleCurve;
        [SerializeField]
        private ObjectScaleCurve activateScaleCurve;

        public void Show(bool shouldShow)
        {
            deactivateScaleCurve.enabled = !shouldShow;
            activateScaleCurve.enabled = shouldShow;
        }
    }
}
