using UnityEngine;

namespace Game.Core.Components
{
    public class MoveComponent
    {
        private readonly Rigidbody _rigidbody;
        private readonly float _speed;

        private Vector3 _extraVelocity;

        public MoveComponent(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Move(Vector3 direction)
        {
            Vector3 velocity = direction * _speed + Vector3.up * _rigidbody.velocity.y;
            velocity += _extraVelocity;

            _rigidbody.velocity = velocity;
            _extraVelocity = Vector3.zero;
        }

        public void AddExtraVelocity(Vector3 velocity)
        {
            _extraVelocity = velocity;
        }
    }
}