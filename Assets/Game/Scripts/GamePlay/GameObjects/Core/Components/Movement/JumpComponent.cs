using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class JumpComponent : ITickable
    {
        private readonly Rigidbody _rigidbody;
        private readonly float _force;
        private readonly float _extraForce;
        private readonly float _delay;

        private float _currentTime;

        public JumpComponent(Rigidbody rigidbody, float force, float extraForce, float delay)
        {
            _rigidbody = rigidbody;
            _force = force;
            _extraForce = extraForce;
            _delay = delay;
        }

        public void Tick()
        {
            if (_currentTime <= 0)
                return;

            _currentTime -= Time.deltaTime;
        }

        public bool Jump()
        {
            if (_currentTime > 0)
                return false;

            Vector3 force = Vector3.up * _force;

            _rigidbody.AddForce(force, ForceMode.Impulse);
            _currentTime = _delay;
            return true;
        }

        public void AddExtraForce(float multiplier)
        {
            var force = Vector3.up * (_extraForce * multiplier);

            _rigidbody.AddForce(force, ForceMode.Force);
        }
    }
}