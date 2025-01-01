using RoR2;
using UnityEngine;

namespace RA2Mod.Survivors.Conscript.Components.Bundled
{

    public class GarrisonController : MonoBehaviour
    {
        [SerializeField]
        private CharacterBody thisBody;
        [SerializeField]
        private GenericOwnership ownershipComponent;
        [SerializeField]
        private HealthComponent healthComponent;
        [SerializeField]
        private TeamFilter teamFilter;
        [SerializeField]
        private GarrisonModel model;

        public void Die()
        {

        }
    }
}
