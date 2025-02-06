using System;
using Game.Core.Components;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Content.Player
{
    public class Character : IInitializable, IDisposable, IMovable, IIInteraction
    {
        private readonly Transform _transform;
        private readonly MoveComponent _mover;
        private readonly GroundChecker _groundChecker;
        private readonly HealthComponent _health;
        private readonly InteractionComponent _interaction;

        private readonly CompositeDisposable _disposables = new();
        private readonly Vector3 _startPosition;

        private Transform _currentParent;

        public Character(Transform transform,
            MoveComponent mover,
            JumpComponent jumper,
            GroundChecker groundChecker,
            HealthComponent health,
            InteractionComponent interaction)
        {
            _transform = transform;
            _mover = mover;
            _groundChecker = groundChecker;
            _health = health;
            _interaction = interaction;

            _startPosition = transform.position;

            SetConditions(groundChecker, jumper);
        }

        public void Initialize()
        {
            _health.Died.Subscribe(_ => OnPlayerDied()).AddTo(_disposables);
            _groundChecker.ParentChanged.Subscribe(OnParentChanged).AddTo(_disposables);
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

        public void Interact()
        {
            _interaction.Interact();
        }

        private void SetConditions(GroundChecker groundChecker, JumpComponent jumper)
        {
            jumper.AddCondition(groundChecker.CheckGround);
        }

        private void OnParentChanged(Transform parent)
        {
            _transform.SetParent(parent);
            _currentParent = parent;
        }

        private void OnPlayerDied()
        {
            _transform.position = _startPosition;
            _health.ResetHealth();
        }
    }
}