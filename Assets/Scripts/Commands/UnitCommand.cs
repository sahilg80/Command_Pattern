using Command.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    public abstract class UnitCommand : ICommand
    {
        public int ActorUnitID;
        public int TargetUnitID;
        public int ActorPlayerID;
        public int TargetPlayerID;

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
    }
}
