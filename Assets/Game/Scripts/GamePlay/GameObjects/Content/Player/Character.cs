using Game.Core.Components;
using UnityEngine;

namespace Game.Content.Player
{
    public class Character : IMover, IJumper
    {
        private readonly MoveComponent _mover;
        private readonly JumpComponent _jumper;
        private readonly GroundChecker _groundChecker;

        public Character(MoveComponent mover,
            JumpComponent jumper,
            GroundChecker groundChecker)
        {
            _mover = mover;
            _jumper = jumper;
            _groundChecker = groundChecker;
        }

        public void Move(Vector3 direction)
        {
            _mover.Move(direction);
        }

        public void Jump()
        {
            if (!_groundChecker.CheckGround())
                return;

            _jumper.Jump();
        }
    }
}