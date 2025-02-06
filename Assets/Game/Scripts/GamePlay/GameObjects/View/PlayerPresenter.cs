using System;
using Game.Content.Player;
using Game.Core.Components;
using UniRx;
using Zenject;

namespace Game.View
{
    public class PlayerPresenter : IInitializable, IDisposable
    {
        private readonly IDamagable _playerHealth;
        private readonly Character _character;
        private readonly PlayerView _view;

        private readonly CompositeDisposable _disposables = new();

        public PlayerPresenter(Character character,
            IDamagable playerHealth,
            PlayerView view)
        {
            _playerHealth = playerHealth;
            _character = character;
            _view = view;
        }

        public void Initialize()
        {
            _playerHealth.Died.Subscribe(_ => OnPlayerDied()).AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        private void OnPlayerDied()
        {
            _view.Die(_character.ResetPlayer);
        }
    }
}