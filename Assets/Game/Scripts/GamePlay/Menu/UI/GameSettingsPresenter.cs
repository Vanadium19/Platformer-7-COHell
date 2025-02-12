using System;
using Game.Menu.Core;
using UniRx;
using Zenject;

namespace Game.Menu.UI
{
    public class GameSettingsPresenter : IInitializable, IDisposable
    {
        private const int DefaultValueCount = 1;

        private readonly MenuFacade _menuFacade;
        private readonly GameSettingsView _view;

        private readonly CompositeDisposable _disposables = new();

        public GameSettingsPresenter(MenuFacade menuFacade, GameSettingsView view)
        {
            _menuFacade = menuFacade;
            _view = view;
        }

        public void Initialize()
        {
            _view.Volume.Skip(DefaultValueCount)
                .Subscribe(OnVolumeChanged)
                .AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        private void OnVolumeChanged(float volume)
        {
            _menuFacade.SetVolume(volume);
        }
    }
}