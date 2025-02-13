using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class FakeMover : IFixedTickable
    {
        private readonly IMovable _target;

        public FakeMover(IMovable target)
        {
            _target = target;
        }

        public void FixedTick()
        {
            _target.Move(Vector3.zero);
        }
    }
}