using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class PlayerJumpController : ITickable
    {
        private readonly IJumper _player;

        public PlayerJumpController(IJumper player)
        {
            _player = player;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _player.Jump();
        }
    }
}