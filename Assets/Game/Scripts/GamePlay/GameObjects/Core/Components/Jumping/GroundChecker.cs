using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class GroundChecker : ITickable, IGroundChecker
    {
        private const int ColliderBufferSize = 1;

        private readonly Transform _jumpPoint;
        private readonly Vector3 _overlapSize;
        private readonly int _layerMask;

        private readonly ReactiveProperty<bool> _isGrounded = new();

        public GroundChecker(GroundCheckParams checkParams)
        {
            _jumpPoint = checkParams.Point;
            _overlapSize = checkParams.OverlapSize;
            _layerMask = checkParams.GroundLayer;
        }

        public IReadOnlyReactiveProperty<bool> IsGrounded => _isGrounded;

        public void Tick()
        {
            _isGrounded.Value = CheckGround();
        }

        private bool CheckGround()
        {
            System.Buffers.ArrayPool<Collider> arrayPool = System.Buffers.ArrayPool<Collider>.Shared;
            Collider[] colliders = arrayPool.Rent(ColliderBufferSize);

            int size = Physics.OverlapBoxNonAlloc(_jumpPoint.position, _overlapSize, colliders, Quaternion.identity, _layerMask);

            arrayPool.Return(colliders);
            return size > 0;
        }
    }
}