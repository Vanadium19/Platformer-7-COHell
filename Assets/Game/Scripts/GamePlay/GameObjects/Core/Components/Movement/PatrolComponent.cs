using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class PatrolComponent : IFixedTickable
    {
        private readonly Transform _transform;
        private readonly Vector3 _startPosition;
        private readonly Vector3 _endPosition;
        private readonly float _speed;

        private Vector3 _targetPosition;

        public PatrolComponent(Transform transform,
            Vector3 startPosition,
            Vector3 endPosition,
            float speed)
        {
            _transform = transform;
            _startPosition = startPosition;
            _endPosition = endPosition;
            _speed = speed;

            _targetPosition = _startPosition;
        }

        public void FixedTick()
        {
            var position = Vector3.MoveTowards(_transform.position, _targetPosition, _speed * Time.fixedDeltaTime);
            _transform.position = position;

            if (_targetPosition == position)
                _targetPosition = _targetPosition == _startPosition ? _endPosition : _startPosition;
        }
    }
}