using UnityEngine;

namespace Game.Core.Components
{
    public class PlayerMoveComponent : MoveComponent
    {
        private readonly MoveParams _params;

        public PlayerMoveComponent(Transform transform,
            Rigidbody rigidbody,
            MoveParams moveParams)
            : base(transform, rigidbody, moveParams.Speed)
        {
            _params = moveParams;
        }

        protected override void UpdateSpeed(ref Vector3 velocity)
        {
            base.UpdateSpeed(ref velocity);

            velocity.y -= _params.GravityScale;

            if (velocity.y < 0)
                velocity.y -= _params.FallFactor;
        }
    }
}