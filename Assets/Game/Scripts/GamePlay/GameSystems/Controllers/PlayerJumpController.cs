using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class PlayerJumpController : ITickable
    {
        private const float MinMultiplier = 0.75f;
        private const float MaxMultiplier = 1f;

        private readonly IJumper _player;

        private float _currentMultiplier;

        public PlayerJumpController(IJumper player)
        {
            _player = player;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_player.Jump())
                    _currentMultiplier = MinMultiplier;

                return;
            }

            if (_currentMultiplier == 0)
                return;

            if (Input.GetKey(KeyCode.Space))
                AddExtraForce();

            if (Input.GetKeyUp(KeyCode.Space) || _currentMultiplier >= MaxMultiplier)
                _currentMultiplier = 0;
        }

        private void AddExtraForce()
        {
            _currentMultiplier = Mathf.Clamp(_currentMultiplier + Time.deltaTime, MinMultiplier, MaxMultiplier);
            _player.AddExtraForce(_currentMultiplier);
        }
    }
}