using System;
using Game.Core.Components;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Content.Player
{
    public class Character : IInitializable, ITickable, IDisposable, IMovable
    {
        private readonly Transform _transform;
        private readonly MoveComponent _mover;
        private readonly GroundChecker _groundChecker;
        private readonly HealthComponent _health;

        private readonly ReactiveProperty<bool> _isMoving = new();
        private readonly CompositeDisposable _disposables = new();

        private readonly Vector3 _startPosition;

        private Transform _currentParent;

        public Character(Transform transform,
            MoveComponent mover,
            JumpComponent jumper,
            GroundChecker groundChecker,
            HealthComponent health)
        {
            _transform = transform;
            _mover = mover;
            _groundChecker = groundChecker;
            _health = health;

            _startPosition = transform.position;

            SetConditions(groundChecker, health, jumper, mover);
        }

        public IReadOnlyReactiveProperty<bool> IsMoving => _isMoving;

        public void Initialize()
        {
            _groundChecker.ParentChanged.Subscribe(OnParentChanged).AddTo(_disposables);
            _health.Died.Subscribe(_ => OnCharacterDied()).AddTo(_disposables);
        }

        public void Tick()
        {
            _isMoving.Value = _mover.IsMoving && !_health.IsDead;
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        public void Move(Vector3 direction)
        {
            _transform.SetParent(null);

            _mover.Move(direction);

            _transform.SetParent(_currentParent);
        }

        public void AddExtraVelocity(Vector3 velocity)
        {
            _mover.AddExtraVelocity(velocity);
        }

        public void ResetPlayer()
        {
            _transform.position = _startPosition;
            _mover.Freeze(false);
            _health.ResetHealth();
        }

        private void SetConditions(GroundChecker groundChecker,
            HealthComponent health,
            JumpComponent jumper,
            MoveComponent mover)
        {
            jumper.AddCondition(groundChecker.CheckGround);
            jumper.AddCondition(() => !health.IsDead);
            mover.AddCondition(() => !health.IsDead);
        }

        private void OnParentChanged(Transform parent)
        {
            _transform.SetParent(parent);
            _currentParent = parent;
        }

        private void OnCharacterDied()
        {
            Debug.Log("Die");
            _mover.Freeze(true);
        }
    }
}