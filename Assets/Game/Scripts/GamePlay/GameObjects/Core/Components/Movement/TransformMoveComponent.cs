using UnityEngine;

namespace Game.Core.Components
{
    public class TransformMoveComponent
    {
        private readonly Transform _transform;
        private readonly float _speed;

        private Vector3 _extraVelocity;

        public TransformMoveComponent(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Move(Vector3 direction)
        {
            Vector3 offset = direction * (_speed * Time.fixedDeltaTime) + _extraVelocity;

            _transform.position += offset;
            _extraVelocity = Vector3.zero;
        }

        public void AddExtraVelocity(Vector3 velocity)
        {
            _extraVelocity += velocity;
        }
    }
}