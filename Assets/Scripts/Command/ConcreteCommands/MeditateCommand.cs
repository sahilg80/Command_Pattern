using Command.Main;

namespace Command.Commands
{
    public class MeditateCommand : UnitCommand
    {
        private bool willHitTarget;

        public MeditateCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);

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
