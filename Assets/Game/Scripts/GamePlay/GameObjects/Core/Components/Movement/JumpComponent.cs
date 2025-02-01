using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class JumpComponent : ITickable
    {
        private readonly Rigidbody _rigidbody;
        private readonly float _force;
        private readonly float _delay;

        private float _currentTime;

        public JumpComponent(Rigidbody rigidbody, float force, float delay)
        {
            _rigidbody = rigidbody;
            _force = force;
            _delay = delay;
        }

        public void Tick()
        {
            if (_currentTime <= 0)
                return;

            _currentTime -= Time.deltaTime;
        }

        public void Jump()
        {
            if (_currentTime > 0)
                return;

            Vector3 force = Vector3.up * _force;

            _rigidbody.AddForce(force, ForceMode.Impulse);
            _currentTime = _delay;
        }
    }
}