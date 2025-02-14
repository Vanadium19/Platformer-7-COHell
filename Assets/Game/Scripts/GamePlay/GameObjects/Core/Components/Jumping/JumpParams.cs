using System;
using UniRx;
using UnityEngine;

namespace Game.Core.Components
{
    [Serializable]
    public struct JumpParams
    {
        [SerializeField] private FloatReactiveProperty _force;
        [SerializeField] private FloatReactiveProperty _extraForce;
        [SerializeField] private float _delay;

        public float Force => _force.Value;
        public float ExtraForce => _extraForce.Value;
        public float Delay => _delay;
    }
}