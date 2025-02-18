using UnityEngine;

namespace Game.View.AnimatorStates
{
    public class OneShotSound : StateMachineBehaviour
    {
        [Tooltip("Nullable")] [SerializeField] private AudioClip _enterClip;
        [Tooltip("Nullable")] [SerializeField] private AudioClip _exitClip;

        private AudioSource _audioSource;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_audioSource == null)
                _audioSource = animator.GetComponent<AudioSource>();

            if (_enterClip != null)
                _audioSource.PlayOneShot(_enterClip);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_exitClip != null)
                _audioSource.PlayOneShot(_exitClip);
        }
    }
}