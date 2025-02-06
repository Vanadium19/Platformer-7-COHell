using System;
using DG.Tweening;
using UnityEngine;

namespace Game.View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Color _color;

        [SerializeField] private int _duration = 2;
        [SerializeField] private float _interval = 0.25f;

        private Color _startColor;

        private void Awake()
        {
            _startColor = _meshRenderer.material.color;
        }

        public void Die(Action callback = null)
        {
            _meshRenderer.material.color = _startColor;

            _meshRenderer.material.DOColor(_color, _interval)
                .SetLoops((int)(_duration / _interval), LoopType.Yoyo)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    callback?.Invoke();
                    _meshRenderer.material.color = _startColor;
                });
        }
    }
}