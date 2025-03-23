using RA2Mod.Survivors.Desolator;
using RoR2;
using RoR2.Projectile;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RA2Mod.General.Components
{
    public abstract class LimitObjectsOfType<T> : MonoBehaviour where T : LimitObjectsOfType<T>, new()
    {
        public abstract int limit { get; }

        [SerializeField]
        private ProjectileController controller;

        public static T[] instances;
        public static int nextIndex;

        void OnEnable()
        {
            if (limit <= -1)
                return;

            if (limit == 0)
            {
                Disable();
                return;
            }

            EnsureArray();

            if (instances[nextIndex] != null)
            {
                instances[nextIndex].Disable();
            }

            instances[nextIndex] = this as T;
            nextIndex = (nextIndex + 1) % limit;
        }

        private void EnsureArray()
        {
            if (instances == null)
            {
                instances = new T[limit];
            }
            if (instances.Length != limit)
            {
                Array.Resize(ref instances, limit);
                nextIndex = 0;
            }
        }

        public virtual void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
