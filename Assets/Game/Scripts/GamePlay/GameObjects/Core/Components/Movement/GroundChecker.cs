using System;
using Game.Content.Environment;
using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class GroundChecker : IInitializable, IDisposable
    {
        private const int ColliderBufferSize = 1;

        private readonly CollisionReceiver _platformTracker;
        private readonly Transform _jumpPoint;
        private readonly Vector3 _overlapSize;
        private readonly int _layerMask;

        public event Action<Transform> ParentChanged;

        public GroundChecker(GroundCheckParams checkParams, CollisionReceiver platformTracker)
        {
            _jumpPoint = checkParams.Point;
            _overlapSize = checkParams.OverlapSize;
            _layerMask = checkParams.GroundLayer;
            _platformTracker = platformTracker;
        }

        public void Initialize()
        {
            _platformTracker.Entered += OnEntered;
            _platformTracker.Exited += OnExited;
        }

        public void Dispose()
        {
            _platformTracker.Entered -= OnEntered;
            _platformTracker.Exited -= OnExited;
        }

        private void OnEntered(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IEntity entity) && CheckNormal(collision))
            {
                if (entity.TryGet(out Platform platform))
                {
                    ParentChanged?.Invoke(collision.collider.transform);
                }
            }
        }

        private void OnExited(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out Platform platform))
                {
                    ParentChanged?.Invoke(null);
                }
            }
        }

        public bool CheckGround()
        {
            System.Buffers.ArrayPool<Collider> arrayPool = System.Buffers.ArrayPool<Collider>.Shared;
            Collider[] colliders = arrayPool.Rent(ColliderBufferSize);

            int size = Physics.OverlapBoxNonAlloc(_jumpPoint.position, _overlapSize, colliders, Quaternion.identity, _layerMask);

            arrayPool.Return(colliders);
            return size > 0;
        }
        
        private bool CheckNormal(Collision target)
        {
            foreach (var contact in target.contacts)
            {
                if (contact.normal == Vector3.up)
                    return true;
            }

            return false;
        }
    }
}