using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Core.Components
{
    public class DelayedPatrolComponent : PatrolComponent
    {
        private readonly float _delay;

        private bool _isReturn;

        public event Action Returned;

        public DelayedPatrolComponent(Transform transform,
            Vector3 startPosition,
            Vector3 endPosition,
            float speed,
            float delay)
            : base(transform, startPosition, endPosition, speed)
        {
            _delay = delay;
        }

        public void Activate()
        {
            base.ChangeTargetPosition();
        }

        protected override void ChangeTargetPosition()
        {
            if (_isReturn)
                Return();
            else
                StartChangePosition().Forget();
        }

        private async UniTaskVoid StartChangePosition()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_delay));

            base.ChangeTargetPosition();
            _isReturn = true;
        }

        private void Return()
        {
            _isReturn = false;
            Returned?.Invoke();
        }
    }
}