using UnityEngine;

namespace Game.Core.Components
{
    public interface IMovable
    {
        public Vector3 Position { get; }

        public void Move(Vector3 direction);
        public void AddExtraVelocity(Vector3 velocity);
    }
}