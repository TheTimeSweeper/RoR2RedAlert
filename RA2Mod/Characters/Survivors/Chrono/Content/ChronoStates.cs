using EntityStates;
using RA2Mod.General.States;
using RA2Mod.Survivors.Chrono.States;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RA2Mod.Survivors.Chrono
{
    public static class ChronoStates
    {
        public static void Init()
        {

            //can I just do this and never worry about forgetting to register a state again?
            //System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(typeof(RA2Plugin));

            //IEnumerable<Type> types = assembly.GetTypes().Where(type => typeof(EntityState).IsAssignableFrom(type));
            //foreach (Type type in types)
            //{
            //    Modules.Content.AddEntityState(type);
            //}


            Modules.Content.AddEntityState(typeof(ChronoCharacterMain));
            Modules.Content.AddEntityState(typeof(ChronoSprintState));
            Modules.Content.AddEntityState(typeof(ChronoSprintStateEpic));
            Modules.Content.AddEntityState(typeof(WindDownState));
            Modules.Content.AddEntityState(typeof(PhaseState));

            Modules.Content.AddEntityState(typeof(ChronoShoot));

            Modules.Content.AddEntityState(typeof(ChronoBombPlace));
            Modules.Content.AddEntityState(typeof(ChronoBombThrow));

            Modules.Content.AddEntityState(typeof(AimChronosphere1));
            Modules.Content.AddEntityState(typeof(AimChronosphere2));
            Modules.Content.AddEntityState(typeof(PlaceChronosphere2));

            Modules.Content.AddEntityState(typeof(AimFreezoSphere));
            Modules.Content.AddEntityState(typeof(PlaceFreezoSphere));

            Modules.Content.AddEntityState(typeof(CastVanishTether));
            Modules.Content.AddEntityState(typeof(VanishingState));
        }
    }
}
