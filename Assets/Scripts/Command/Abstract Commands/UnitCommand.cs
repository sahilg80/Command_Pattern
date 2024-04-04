using Command.AbstractCommands;
using Command.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Command.AbstractCommands
{
    public abstract class UnitCommand : ICommand
    {
        public CommandData CommandData;

        // References to the actor and target units, accessible by subclasses.
        protected UnitController actorUnit;
        protected UnitController targetUnit;

        /// <summary>
        /// Abstract method to execute the unit command. Must be implemented by concrete subclasses.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Abstract method to determine whether the command will successfully hit its target.
        /// Must be implemented by concrete subclasses.
        /// </summary>
        public abstract bool WillHitTarget();

        public void SetActorUnit(UnitController actorUnit) => this.actorUnit = actorUnit;

        public void SetTargetUnit(UnitController targetUnit) => this.targetUnit = targetUnit;

    }

    public struct CommandData
    {
        public int ActorUnitID;
        public int TargetUnitID;
        public int ActorPlayerID;
        public int TargetPlayerID;

        public CommandData(int ActorUnitID, int TargetUnitID, int ActorPlayerID, int TargetPlayerID)
        {
            this.ActorUnitID = ActorUnitID;
            this.TargetUnitID = TargetUnitID;
            this.ActorPlayerID = ActorPlayerID;
            this.TargetPlayerID = TargetPlayerID;
        }
    }
}
