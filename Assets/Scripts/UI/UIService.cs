using System.Collections.Generic;
using UnityEngine;
using Command.Main;
using Command.Input;
using Command.Commands;

namespace Command.UI
{
    public class UIService : MonoBehaviour
    {
        [Header("Battle Selection UI:")]
        private BattleSelectionUIController battleSelectionController;
        [SerializeField] private BattleSelectionUIView battleSelectionView;
        [SerializeField] private BattleButtonView battleButtonPrefab;

        [Header("Gameplay UI:")]
        private GameplayUIController gameplayController;
        [SerializeField] private GameplayUIView gameplayView;

        [Header("Action Selection UI:")]
        private ActionSelectionUIController actionSelectionController;
        [SerializeField] private ActionSelectionUIView actionSelectionView;
        [SerializeField] private ActionButtonView actionButtonPrefab;

        [Header("Battle End UI:")]
        private BattleEndUIController battleEndController;
        [SerializeField] private BattleEndUIView battleEndView;

        private void Start()
        {
            battleSelectionController = new BattleSelectionUIController(battleSelectionView, battleButtonPrefab);
            gameplayController = new GameplayUIController(gameplayView);
            actionSelectionController = new ActionSelectionUIController(actionSelectionView, actionButtonPrefab);
            battleEndController = new BattleEndUIController(battleEndView);
        }

        public void Init(int battleCount) => ShowBattleSelectionView(battleCount);

        private void ShowBattleSelectionView(int battleCount) => battleSelectionController.Show(battleCount);

        public void ShowGameplayView() => gameplayController.Show();

        public void ShowActionSelectionView(List<CommandType> executableActions)
        {
            actionSelectionController.Show(executableActions);
            GameService.Instance.InputService.SetInputState(InputState.SELECTING_ACTION);
        }

        public void ShowBattleEndUI(int winnerId)
        {
            battleEndController.SetWinner(winnerId);
            battleEndController.Show();
        }

        public void HideBattleEndUI() => battleEndController.Hide();

        public void UpdateTurnNumber(int turnNumber) => gameplayController.SetTurnNumber(turnNumber);

        public void ActionMissed() => gameplayController.ShowMissedAction();

    }
}