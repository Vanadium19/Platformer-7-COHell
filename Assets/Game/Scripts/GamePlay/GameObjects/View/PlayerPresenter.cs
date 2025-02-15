using System;
using Game.Content.Player;
using Game.Core.Components;
using UniRx;
using Zenject;

namespace Game.View
{
    public class PlayerPresenter : IInitializable, IDisposable
    {
        private readonly IGroundChecker _groundChecker;
        private readonly IDamagable _playerHealth;
        private readonly IJumper _jumper;

        private readonly Character _character;
        private readonly PlayerView _view;

        private readonly CompositeDisposable _disposables = new();

        public PlayerPresenter(Character character,
            IGroundChecker groundChecker,
            IDamagable playerHealth,
            IJumper jumper,
            PlayerView view)
        {
            _groundChecker = groundChecker;
            _playerHealth = playerHealth;
            _character = character;
            _jumper = jumper;
            _view = view;
        }

        public void Initialize()
        {
            _groundChecker.IsGrounded.Subscribe(_view.SetGroundAnimation).AddTo(_disposables);
            _playerHealth.Died.Subscribe(_ => _view.Die()).AddTo(_disposables);
            _character.IsMoving.Subscribe(_view.SetMoveAnimation).AddTo(_disposables);
            _character.IsFalling.Subscribe(_view.SetFallAnimation).AddTo(_disposables);
            _jumper.Jumped.Subscribe(_ => _view.SetJumpAnimation()).AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}