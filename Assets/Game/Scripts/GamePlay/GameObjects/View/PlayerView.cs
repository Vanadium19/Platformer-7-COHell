using System;
using DG.Tweening;
using Game.Common;
using Game.Content.Player;
using UnityEngine;

namespace Game.View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private SkinnedMeshRenderer _meshRenderer;
        [SerializeField] private Color _color;

        [SerializeField] private int _duration = 2;
        [SerializeField] private float _interval = 0.25f;

        private Color _startColor;

        private void Awake()
        {
            _startColor = _meshRenderer.material.color;
        }

        public void Die()
        {
            _animator.SetTrigger(AnimatorParams.Die);
            _meshRenderer.material.color = _startColor;

            _meshRenderer.material.DOColor(_color, _interval)
                .SetLoops((int)(_duration / _interval), LoopType.Yoyo)
                .SetEase(Ease.Linear)
                .OnComplete(() => _meshRenderer.material.color = _startColor);
        }

        public void SetGroundAnimation(bool value)
        {
            _animator.SetBool(AnimatorParams.IsGrounded, value);
        }

        public void SetMoveAnimation(bool value)
        {
            _animator.SetBool(AnimatorParams.IsMoving, value);
        }

        public void SetJumpAnimation()
        {
            _animator.SetTrigger(AnimatorParams.Jump);
        }

        public void SetFallAnimation(bool value)
        {
            _animator.SetBool(AnimatorParams.IsFalling, value);
        }
    }
}