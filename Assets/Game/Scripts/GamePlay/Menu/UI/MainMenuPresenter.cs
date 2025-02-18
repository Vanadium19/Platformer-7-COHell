using System;
using Game.Menu.Core;
using UniRx;
using Zenject;

namespace Game.Menu.UI
{
    public class MainMenuPresenter : IInitializable, IDisposable
    {
        private readonly MenuFacade _menu;
        private readonly MainMenuView _view;

        private readonly CompositeDisposable _disposable = new();

        public MainMenuPresenter(MenuFacade menu, MainMenuView view)
        {
            _menu = menu;
            _view = view;
        }


        public void Initialize()
        {
            _view.OnPlayButtonPressed.Subscribe(_ => _menu.LoadGame()).AddTo(_disposable);
            _view.OnExitButtonPressed.Subscribe(_ => _menu.ExitGame()).AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}