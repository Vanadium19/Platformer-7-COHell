using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core.Components
{
    public class MoveComponent : EntityComponent
    {
        private readonly Transform _transform;
        private readonly Rigidbody _rigidbody;
        private readonly float _speed;

        private Vector3 _extraVelocity;

        public MoveComponent(Transform transform, Rigidbody rigidbody, float speed)
        {
            _transform = transform;
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public bool IsMoving { get; private set; }

        public void Move(Vector3 direction)
        {
            if (_rigidbody.isKinematic)
                return;

            if (!CheckConditions())
                return;

            Vector3 velocity = direction * _speed + Vector3.up * _rigidbody.velocity.y;
            velocity = _transform.rotation * velocity;
            velocity += _extraVelocity;

            IsMoving = !Mathf.Approximately(velocity.x, 0f);

            _rigidbody.velocity = velocity;
            _extraVelocity = Vector3.zero;
        }

        public void AddExtraVelocity(Vector3 velocity)
        {
            _extraVelocity = velocity;
        }

        public void Freeze(bool value)
        {
            if (value)
            {
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.angularVelocity = Vector3.zero;
            }

            _rigidbody.isKinematic = value;
        }
    }
}