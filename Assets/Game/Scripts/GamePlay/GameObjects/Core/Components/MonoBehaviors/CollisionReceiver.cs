using System;
using UnityEngine;

namespace Game.Core.Components
{
    public class CollisionReceiver : MonoBehaviour
    {
        public event Action<Collision> Entered;
        public event Action<Collision> Exited;

        private void OnCollisionEnter(Collision other)
        {
            Entered?.Invoke(other);
        }

        private void OnCollisionExit(Collision other)
        {
            Exited?.Invoke(other);
        }
    }
}