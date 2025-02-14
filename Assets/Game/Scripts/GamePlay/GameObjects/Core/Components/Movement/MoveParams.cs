using System;
using UniRx;
using UnityEngine;

namespace Game.Core.Components
{
    [Serializable]
    public struct MoveParams
    {
        [SerializeField] private FloatReactiveProperty _speed;
        [SerializeField] private FloatReactiveProperty _fallFactor;
        [SerializeField] private FloatReactiveProperty _gravityScale;

        public float Speed => _speed.Value;
        public float FallFactor => _fallFactor.Value;
        public float GravityScale => _gravityScale.Value;
    }
}