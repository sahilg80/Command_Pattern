using Command.Main;

namespace Command.Commands
{
    public class AttackStanceCommand : UnitCommand
    {
        private bool willHitTarget;

        public AttackStanceCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.AttackStance).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override bool WillHitTarget() => true;

        public override void Undo()
        {
            if (willHitTarget)
            {
                targetUnit.RestoreHealth(actorUnit.CurrentPower);
                actorUnit.Owner.ResetCurrentActiveUnit();
            }
        }
    }
}
