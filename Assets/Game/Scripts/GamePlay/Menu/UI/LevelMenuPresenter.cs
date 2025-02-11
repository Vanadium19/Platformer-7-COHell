using System;
using Game.Controllers;
using Game.Menu.Core;
using UniRx;
using Zenject;

namespace Game.Menu.UI
{
    public class LevelMenuPresenter : IInitializable, IDisposable
    {
        private readonly LevelController _levelController;
        private readonly MenuFacade _menuFacade;
        private readonly LevelMenu _levelMenu;

        private readonly CompositeDisposable _disposables = new();

        public LevelMenuPresenter(LevelController levelController,
            MenuFacade menuFacade,
            LevelMenu levelMenu)
        {
            _levelController = levelController;
            _menuFacade = menuFacade;
            _levelMenu = levelMenu;
        }

        public void Initialize()
        {
            _levelController.LevelLost.Subscribe(_ => OnLevelLost()).AddTo(_disposables);
            _levelMenu.LevelRestarted.Subscribe(_ => OnLevelRestarted()).AddTo(_disposables);
            _levelMenu.Exited.Subscribe(_ => OnExited()).AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        private void OnLevelLost()
        {
            _menuFacade.PauseGame();
            _levelMenu.EnableGameOverPopup(true);
        }

        private void OnLevelRestarted()
        {
            _menuFacade.ContinueGame();
            _levelMenu.EnableGameOverPopup(false);
        }

        private void OnExited()
        {
            _menuFacade.ReturnToMainMenu();
        }
    }
}