using UnityEngine;

namespace Game.Core.Components
{
    public class GroundChecker
    {
        private const int ColliderBufferSize = 1;

        private readonly Transform _jumpPoint;
        private readonly Vector3 _overlapSize;
        private readonly int _layerMask;

        public GroundChecker(GroundCheckParams checkParams)
        {
            _jumpPoint = checkParams.Point;
            _overlapSize = checkParams.OverlapSize;
            _layerMask = checkParams.GroundLayer;
        }

        public bool CheckGround()
        {
            System.Buffers.ArrayPool<Collider> arrayPool = System.Buffers.ArrayPool<Collider>.Shared;
            Collider[] colliders = arrayPool.Rent(ColliderBufferSize);

            int size = Physics.OverlapBoxNonAlloc(_jumpPoint.position, _overlapSize, colliders, Quaternion.identity, _layerMask);

            arrayPool.Return(colliders);
            return size > 0;
        }
    }
}