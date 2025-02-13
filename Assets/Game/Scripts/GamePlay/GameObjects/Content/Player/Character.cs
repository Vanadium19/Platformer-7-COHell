using System;
using Game.Core.Components;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Content.Player
{
    public class Character : IInitializable, ITickable, IDisposable
    {
        private readonly Transform _transform;
        private readonly MoveComponent _mover;
        private readonly HealthComponent _health;

        private readonly ReactiveProperty<bool> _isMoving = new();
        private readonly CompositeDisposable _disposables = new();

        private Vector3 _spawnPosition;

        public Character(Transform transform,
            MoveComponent mover,
            JumpComponent jumper,
            GroundChecker groundChecker,
            HealthComponent health)
        {
            _transform = transform;
            _mover = mover;
            _health = health;

            _spawnPosition = transform.position;

            SetConditions(groundChecker, health, jumper, mover);
        }

        public IReadOnlyReactiveProperty<bool> IsMoving => _isMoving;

        public void Initialize()
        {
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

        public void SetParent(Transform parent)
        {
            _transform.SetParent(parent);
        }

        public void ResetPlayer()
        {
            _transform.position = _spawnPosition;
            _mover.Freeze(false);
            _health.ResetHealth();
        }

        public void SetSpawnPosition(Vector3 value)
        {
            _spawnPosition = value;
        }

        private void SetConditions(GroundChecker groundChecker,
            HealthComponent health,
            JumpComponent jumper,
            MoveComponent mover)
        {
            jumper.AddCondition(() => groundChecker.IsGrounded.Value);
            jumper.AddCondition(() => !health.IsDead);
            mover.AddCondition(() => !health.IsDead);
        }

        private void OnCharacterDied()
        {
            _mover.Freeze(true);
        }
    }
}