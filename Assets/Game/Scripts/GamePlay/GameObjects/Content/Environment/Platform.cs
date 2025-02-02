using Game.Core.Components;
using UnityEngine;

namespace Game.Content.Environment
{
    public class Platform : IMovable
    {
        private readonly TransformMoveComponent _mover;
        private readonly Transform _transform;

        public Platform(Transform transform,
            TransformMoveComponent mover)
        {
            _transform = transform;
            _mover = mover;
        }

        public Vector3 Position => _transform.position;

        public void Move(Vector3 direction)
        {
            _mover.Move(direction);
        }

        public void AddExtraVelocity(Vector3 velocity)
        {
            _mover.AddExtraVelocity(velocity);
        }
    }
}