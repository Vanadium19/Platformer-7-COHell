using System;
using DG.Tweening;
using UnityEngine;

namespace Game.View
{
    public class IncludedPlatformView : MonoBehaviour
    {
        private const int Loops = 2;

        [SerializeField] private float _angleX = 45f;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private Transform _lever;

        public void StartLeverAnimation(Action callback)
        {
            var rotation = new Vector3(_angleX, 0, 0);

            _lever.DORotate(rotation, _duration)
                .SetEase(Ease.Linear)
                .SetLoops(Loops, LoopType.Yoyo)
                .OnComplete(() => callback?.Invoke());
        }
    }
}