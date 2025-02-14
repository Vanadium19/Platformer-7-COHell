using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class PlayerJumpController : ITickable, IFixedTickable
    {
        private const float MinMultiplier = 0.75f;
        private const float MaxMultiplier = 1f;

        private readonly IJumper _player;

        private float _currentMultiplier;
        private bool _isJumping;

        public PlayerJumpController(IJumper player)
        {
            _player = player;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isJumping = _player.Jump();

                if (_isJumping)
                    _currentMultiplier = MinMultiplier;
            }

            if (Input.GetKeyUp(KeyCode.Space) || _currentMultiplier >= MaxMultiplier)
            {
                _isJumping = false;
                _currentMultiplier = 0;
            }
        }

        public void FixedTick()
        {
            if (_isJumping)
                AddExtraForce();
        }

        private void AddExtraForce()
        {
            _currentMultiplier = Mathf.Clamp(_currentMultiplier + Time.fixedDeltaTime, MinMultiplier, MaxMultiplier);
            _player.AddExtraForce(_currentMultiplier);
        }
    }
}