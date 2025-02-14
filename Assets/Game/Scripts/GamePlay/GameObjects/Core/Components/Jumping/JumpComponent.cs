using UnityEngine;
using Zenject;

namespace Game.Core.Components
{
    public class JumpComponent : EntityComponent, ITickable, IJumper
    {
        private readonly Rigidbody _rigidbody;
        private readonly JumpParams _params;

        private float _currentTime;

        public JumpComponent(Rigidbody rigidbody, JumpParams jumpParams)
        {
            _rigidbody = rigidbody;
            _params = jumpParams;
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

            if (!CheckConditions())
                return false;

            Vector3 force = Vector3.up * _params.Force;

            _rigidbody.AddForce(force, ForceMode.Impulse);
            _currentTime = _params.Delay;
            return true;
        }

        public void AddExtraForce(float multiplier)
        {
            var force = Vector3.up * (_params.ExtraForce * multiplier);

            _rigidbody.AddForce(force, ForceMode.Force);
        }
    }
}