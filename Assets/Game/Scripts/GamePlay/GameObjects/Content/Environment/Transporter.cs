using System;
using Game.Core;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class Transporter : IInitializable, IFixedTickable, IDisposable
    {
        private readonly TriggerReceiver _playerTracker;
        private readonly Transform _transform;
        private readonly float _speed;

        private IMovable _target;

        public Transporter(TriggerReceiver playerTracker, Transform transform, float speed)
        {
            _playerTracker = playerTracker;
            _transform = transform;
            _speed = speed;
        }

        public void Initialize()
        {
            _playerTracker.Entered += OnEntered;
            _playerTracker.Exited += OnExited;
        }

        public void FixedTick()
        {
            if (_target != null)
                _target.AddExtraVelocity(_transform.forward * _speed);
        }

        public void Dispose()
        {
            _playerTracker.Entered -= OnEntered;
            _playerTracker.Exited -= OnExited;
        }

        private void OnEntered(Collider target)
        {
            if (target.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out IMovable player))
                {
                    _target = player;
                }
            }
        }

        private void OnExited(Collider target)
        {
            if (target.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out IMovable player))
                {
                    _target = null;
                }
            }
        }
    }
}