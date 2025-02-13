using Game.Core;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class BoxPool : MonoMemoryPool<Vector3, Entity>
    {
        protected override void Reinitialize(Vector3 position, Entity entity)
        {
            entity.Get<Transform>().position = position;
        }
    }
}