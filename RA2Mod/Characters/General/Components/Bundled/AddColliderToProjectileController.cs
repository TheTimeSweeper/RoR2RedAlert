using RoR2.Projectile;
using UnityEngine;

namespace RA2Mod.General.Components.Bundled
{
    public class AddColliderToProjectileController : MonoBehaviour
    {
        [SerializeField]
        private ProjectileController projectileController;

        [SerializeField]
        private Collider[] colliders;

        void Awake()
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
                HG.ArrayUtils.ArrayAppend<Collider>(ref projectileController.myColliders, in colliders[i]);
            }
        }
    }
}
