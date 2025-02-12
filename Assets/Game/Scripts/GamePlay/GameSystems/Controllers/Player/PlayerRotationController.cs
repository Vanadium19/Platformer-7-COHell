using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class PlayerRotationController : ITickable
    {
        private const string Axis = "Mouse X";

        private readonly IRotater _rotater;

        public PlayerRotationController(IRotater rotater)
        {
            _rotater = rotater;
        }

        public void Tick()
        {
            if (Time.timeScale == 0)
                return;

            float angle = Input.GetAxis(Axis);

            _rotater.Rotate(angle);
        }
    }
}