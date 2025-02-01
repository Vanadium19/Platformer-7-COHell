using Game.Core.Components;
using UnityEngine;

namespace Game.Content.Player
{
    public class Character : IMover, IJumper
    {
        private readonly MoveComponent _mover;
        private readonly JumpComponent _jumper;

        public Character(MoveComponent mover, JumpComponent jumper)
        {
            _mover = mover;
            _jumper = jumper;
        }


        public void Move(Vector3 direction)
        {
            _mover.Move(direction);
        }

        public void Jump()
        {
            _jumper.Jump();
        }
    }
}