using UnityEngine;

namespace Game.Common
{
    public static class AnimatorParams
    {
        public static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
        public static readonly int IsFalling = Animator.StringToHash("IsFalling");
        public static readonly int IsMoving = Animator.StringToHash("IsMoving");
        
        public static readonly int Jump = Animator.StringToHash("Jump");
        public static readonly int Die = Animator.StringToHash("Die");
    }
}