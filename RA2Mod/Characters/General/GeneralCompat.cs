using EntityStates;
using RA2Mod.Modules.Characters;
using RobDriver.Modules.Weapons;
using RoR2;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using VRAPI;
using static DriverWeaponDef;

namespace RA2Mod.General
{
    public static class GeneralCompat
    {
        public static bool TinkersSatchelInstalled;
        public static bool AetheriumInstalled;
        public static bool ScepterInstalled;
        public static bool VREnabled;
        public static bool driverInstalled;

        public static void Init()
        {
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.ThinkInvisible.TinkersSatchel"))
            {
                TinkersSatchelInstalled = true;
            }
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.KomradeSpectre.Aetherium"))
            {
                AetheriumInstalled = true;
            }
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.DestroyedClone.AncientScepter"))
            {
                ScepterInstalled = true;
            }
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.rob.Driver"))
            {
                driverInstalled = true;
            }
        }

        internal static int TryGetScepterCount(Inventory inventory)
        {
            if (!ScepterInstalled)
                return 0;

            return GetScepterCount(inventory);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static int GetScepterCount(Inventory inventory)
        {
            return inventory.GetItemCount(AncientScepter.AncientScepterItem.instance.ItemDef);
        }

        #region vr helpers
        public static Ray GetAimRay(this BaseState state, bool dominant = true)
        {
            if (IsLocalVRPlayer(state.characterBody))
            {
                return GetVrAimRay(dominant);
            }
            return state.GetAimRay();
        }
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static Ray GetVrAimRay(bool dominant)
        {
            return dominant ? MotionControls.dominantHand.aimRay : MotionControls.nonDominantHand.aimRay;
        }

        public static Ray GetAimRayCamera(BaseState state)
        {
            if (IsLocalVRPlayer(state.characterBody))
            {
                return GetVRAimRayCamera();
            }
            return state.GetAimRay();
        }
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static Ray GetVRAimRayCamera()
        {
            //todo teslamove no camera.main in fixedupdate
            Camera main = Camera.main;
            return new Ray(main.transform.position, main.transform.forward);
        }

        public static ChildLocator GetModelChildLocator(this BaseState state, bool dominant = true)
        {
            if (IsLocalVRPlayer(state.characterBody))
            {
                return GetVRChildLocator(dominant);
            }
            return state.GetModelChildLocator();
        }
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static ChildLocator GetVRChildLocator(bool dominant)
        {
            if (dominant)
            {
                return MotionControls.dominantHand.transform.GetComponentInChildren<ChildLocator>();
            }
            else
            {
                return MotionControls.nonDominantHand.transform.GetComponentInChildren<ChildLocator>();
            }
        }

        public static bool IsLocalVRPlayer(CharacterBody body)
        {
            return General.GeneralCompat.VREnabled && body == LocalUserManager.GetFirstLocalUser().cachedBody;
        }
        #endregion vr helpers
    }

    #region driver helpers
    //when update
    //internal abstract class DriverCompatWeapon<TWeapon, TCharacter> : DriverWeapon<TWeapon> where TWeapon : DriverWeapon<TWeapon> where TCharacter : CharacterBase<TCharacter>, new()
    //{
    //    public override GameObject crosshairPrefab => characterBase.prefabCharacterBody.defaultCrosshairPrefab;
    //    public override string uniqueDropBodyName => characterBase.bodyName;

    //    public abstract TCharacter characterBase { get; }

    //    public override void Init()
    //    {
    //        CreateWeapon();
    //    }
    //}

    internal abstract class DriverCompatWeapon<TWeapon, TCharacter> : BaseWeapon<TWeapon> where TWeapon : BaseWeapon<TWeapon> where TCharacter : CharacterBase<TCharacter>, new()
    {
        public override string iconName => "";
        public override string weaponNameToken => "";
        public override string weaponDesc => "";
        public override string weaponName => "";

        new public abstract string nameToken { get; }
        new public abstract string descriptionToken { get; }
        new public abstract Texture icon { get; }

        public override GameObject crosshairPrefab => characterBase.prefabCharacterBody.defaultCrosshairPrefab;
        public override string uniqueDropBodyName => characterBase.bodyName;

        public abstract TCharacter characterBase { get; }

        public override void Init()
        {
            CreateWeapon();
            weaponDef.nameToken = nameToken;
            weaponDef.descriptionToken = descriptionToken;
            weaponDef.icon = icon;
        }
    }
    #endregion
}
