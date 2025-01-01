using UnityEngine;
using UnityEngine.Events;

namespace RA2Mod.General.Components.Bundled
{
    public class DetachOnDestroy : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent onDestroyEvent;

        [SerializeField]
        private Transform[] toDetach;

        private void OnDestroy()
        {
            for (int i = 0; i < toDetach.Length; i++)
            {
                if (toDetach[i])
                {
                    toDetach[i].parent = null;
                }
            }
        }
    }
}
