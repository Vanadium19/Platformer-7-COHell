using System;
using UnityEngine;

namespace Game.Content.Environment
{
    [Serializable]
    public struct BoxSpawnerParams
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float _delay;
        
        public Vector3 Position => _transform.position;
        public float Delay => _delay;
    }
}