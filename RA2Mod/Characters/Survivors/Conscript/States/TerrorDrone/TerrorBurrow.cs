using EntityStates;
using EntityStates.Engi.SpiderMine;

namespace RA2Mod.Survivors.Conscript.States.TerrorDrone
{
    //uh probably not. yeah I'm just gonna keep funny hooking
    public class TerrorBurrow : Burrow {

        public override void ModifyNextState(EntityState nextState)
        {
            if(nextState is WaitForStick)
            {
                outer.SetNextState(new TerrorWaitForStick());
            }

            if (nextState is WaitForTarget)
            {
                outer.SetNextState(new TerrorWaitForTarget());
            }
        }
    }

    public class TerrorWaitForStick : WaitForStick
    {
        public override void ModifyNextState(EntityState nextState)
        {
            if (nextState is Burrow)
            {
                outer.SetNextState(new TerrorBurrow());
            }
        }
    }

    public class TerrorWaitForTarget : WaitForTarget
    {

        public override void ModifyNextState(EntityState nextState)
        {
            if (nextState is WaitForStick)
            {
                outer.SetNextState(new TerrorWaitForStick());
            }

            if (nextState is WaitForTarget)
            {
                outer.SetNextState(new TerrorWaitForTarget());
            }
        }
    }

    public class TerrorChaseTarget : ChaseTarget { }

}
