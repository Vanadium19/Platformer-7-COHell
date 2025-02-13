using System;
using System.Collections.Generic;
using Game.Core;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class Transporter : IFixedTickable
    {
        private readonly Transform _transform;
        private readonly float _speed;

        private readonly List<IMovable> _targets = new();

        public Transporter(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void FixedTick()
        {
            foreach (var target in _targets)
                target.AddExtraVelocity(_transform.forward * _speed);
        }

        public void AddTarget(IMovable target)
        {
            if (_targets == null)
                return;

            _targets.Add(target);
        }

        public void RemoveTarget(IMovable target)
        {
            if (_targets == null)
                return;

            _targets.Remove(target);
        }
    }
}