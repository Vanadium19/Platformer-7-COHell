using System;
using DG.Tweening;
using Game.Content.Player;
using UnityEngine;

namespace Game.View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Color _color;
        
        private Character _character;
        
        [SerializeField] private int _duration = 2;
        [SerializeField] private float _interval = 0.25f;

        private Animator _animator;
        
        private Color _startColor;

        private void Awake()
        {
            _startColor = _meshRenderer.material.color;
        }

        public void SetMoveAnimation(bool value)
        {
            Debug.Log($"Run {value}");
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