using UnityEngine;

namespace Game.View.AnimatorStates
{
    public class ConstantSound : StateMachineBehaviour
    {
        private AudioSource _audioSource;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_audioSource == null)
                _audioSource = animator.GetComponent<AudioSource>();

            _audioSource.Play();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _audioSource.Stop();
        }
    }
}