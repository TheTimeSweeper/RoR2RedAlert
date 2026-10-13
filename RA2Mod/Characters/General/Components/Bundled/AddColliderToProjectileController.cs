using RoR2.Projectile;
using UnityEngine;

//todo update namespace to RA2Mod.General.Components.Bundled on here and on script in unity
namespace RA2Mod.General.Components
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
                HG.ArrayUtils.ArrayAppend(ref projectileController.myColliders, in colliders[i]);
            }
        }
    }
}
