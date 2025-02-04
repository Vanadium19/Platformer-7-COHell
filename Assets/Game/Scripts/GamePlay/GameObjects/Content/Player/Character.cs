using System;
using Game.Core.Components;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Content.Player
{
    public class Character : IInitializable, IDisposable, IDamagable, IMovable, IJumper, IIInteraction
    {
        private readonly Transform _transform;
        private readonly MoveComponent _mover;
        private readonly JumpComponent _jumper;
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
            _jumper = jumper;
            _groundChecker = groundChecker;
            _health = health;
            _interaction = interaction;

            _startPosition = transform.position;
        }

        public Vector3 Position => _transform.position;

        public void Initialize()
        {
            _health.Died.Subscribe(_=>OnPlayerDied()).AddTo(_disposables);
            _groundChecker.ParentChanged.Subscribe(OnParentChanged).AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
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

        public bool Jump()
        {
            if (!_groundChecker.CheckGround())
                return false;

            return _jumper.Jump();
        }

        public void AddExtraForce(float multiplier)
        {
            _jumper.AddExtraForce(multiplier);
        }

        public void Interact()
        {
            _interaction.Interact();
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