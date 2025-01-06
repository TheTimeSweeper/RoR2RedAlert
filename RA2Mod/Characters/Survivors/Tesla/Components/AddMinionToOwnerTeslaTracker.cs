using RoR2;
using UnityEngine;

namespace RA2Mod.Survivors.Tesla.Components
{
    public class AddMinionToOwnerTeslaTracker : MonoBehaviour
    {
        private TeslaTowerControllerController _ownerTowerController;

        void Start()
        {
            GameObject ownerBodyObject = GetComponent<CharacterBody>().master.minionOwnership.ownerMaster.GetBodyObject();
            if(ownerBodyObject != null && ownerBodyObject.TryGetComponent(out _ownerTowerController))
            {
                _ownerTowerController.addNotTower(gameObject);
            }
        }

        void OnDestroy()
        {
            if(_ownerTowerController != null)
            {
               _ownerTowerController.removeNotTower(gameObject);
            }
        }
    }
}