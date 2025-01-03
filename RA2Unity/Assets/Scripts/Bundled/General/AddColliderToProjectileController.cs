using RoR2.Projectile;
using UnityEngine;

namespace RA2Mod.General.Components
{
    public class AddColliderToProjectileController : MonoBehaviour
    {
        [SerializeField]
        private ProjectileController projectileController;

        [SerializeField]
        private Collider[] colliders;
    }
}
