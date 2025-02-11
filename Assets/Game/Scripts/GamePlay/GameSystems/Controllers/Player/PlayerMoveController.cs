using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class PlayerMoveController : IFixedTickable
    {
        private const string XAxis = "Horizontal";
        private const string ZAxis = "Vertical";

        private readonly IMovable _player;

        public PlayerMoveController(IMovable player)
        {
            _player = player;
        }

        public void FixedTick()
        {
            Vector3 direction = Input.GetAxis(XAxis) * Vector3.right + Input.GetAxis(ZAxis) * Vector3.forward;

            _player.Move(direction);
        }
    }
}