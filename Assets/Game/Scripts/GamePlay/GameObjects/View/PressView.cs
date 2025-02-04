using System;
using DG.Tweening;
using UnityEngine;

namespace Game.View
{
    public class PressView : MonoBehaviour
    {
        [SerializeField] private float _upTime;
        [SerializeField] private float _downTime;

        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _downPosition;

        private Vector3 _startPosition;

        private void Awake()
        {
            _startPosition = transform.position;
        }

        private void Start()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(_transform.DOMove(_downPosition.position, _downTime))
                .Append(_transform.DOMove(_startPosition, _upTime))
                .SetLoops(-1, LoopType.Restart);
        }
    }
}