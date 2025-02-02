using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class PointsMoveController : IInitializable, IFixedTickable
    {
        private const float Lapping = 0.05f;

        private readonly IMovable _movable;

        private readonly Vector3 _startPosition;
        private readonly Vector3 _endPosition;

        private Vector3 _currentPosition;

        public PointsMoveController(IMovable movable,
            Vector3 startPosition,
            Vector3 endPosition)
        {
            _movable = movable;
            _startPosition = startPosition;
            _endPosition = endPosition;
        }

        public void Initialize()
        {
            _currentPosition = _startPosition;
        }

        public void FixedTick()
        {
            Move();
        }

        private void Move()
        {
            Vector3 direction = (_currentPosition - _movable.Position).normalized;

            _movable.Move(direction);

            if (Vector3.Distance(_movable.Position, _currentPosition) <= Lapping)
                _currentPosition = _currentPosition == _startPosition ? _endPosition : _startPosition;
        }
    }
}