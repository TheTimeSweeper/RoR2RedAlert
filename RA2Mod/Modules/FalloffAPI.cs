using Mono.Cecil.Cil;
using MonoMod.Cil;
using RoR2;
using System;
using System.Collections.Generic;
using System.Text;

namespace RA2Mod.Modules
{
    public static class FalloffAPI
    {
        public delegate float GetFalloffModel(float distance);

        static FalloffAPI()
        {
            VanillaFalloffModelCount = Enum.GetValues(typeof(BulletAttack.FalloffModel)).Length;
        }

        private static Dictionary<BulletAttack.FalloffModel, GetFalloffModel> falloffModels = new Dictionary<BulletAttack.FalloffModel, GetFalloffModel>();

        private static int VanillaFalloffModelCount;
        private static int ModdedFalloffModelCount;

        internal static void SetHooks()
        {
            IL.RoR2.BulletAttack.CalcFalloffFactor += BulletAttack_CalcFalloffFactor;
        }

        private static void BulletAttack_CalcFalloffFactor(MonoMod.Cil.ILContext il)
        {

            ////if (!this.passedDetonationRadius && magnitude <= ChaseTarget.triggerRadius)
            //ILCursor cursor = new ILCursor(il);

            //cursor.GotoNext(MoveType.After,
            //    instruction => instruction.MatchRet(),
            //    instruction => instruction.MatchLdcR4(1),
            //    instruction => instruction.MatchRet()
            //    );

            //cursor.Emit(OpCodes.Ldarg_0);
            //cursor.Emit(OpCodes.Ldarg_1);
            //cursor.EmitDelegate<Func<BulletAttack.FalloffModel, float, bool>>((falloff, distsance)=>
            //{

            //});
        }

        //public static BulletAttack.FalloffModel RegisterFalloffModel()
        //{
        
        //}

    }
}
