using Game.Core.Components;
using UnityEngine;

namespace Game.Content.Player
{
    public class Character : IMover
    {
        private readonly MoveComponent _mover;

        public Character(MoveComponent mover)
        {
            _mover = mover;
        }


        public void Move(Vector3 direction)
        {
            _mover.Move(direction);
        }
    }
}