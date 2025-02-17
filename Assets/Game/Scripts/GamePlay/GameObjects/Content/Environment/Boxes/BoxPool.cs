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

        protected override void OnDespawned(Entity item)
        {
            base.OnDespawned(item);

            item.Get<Transform>().position = Vector3.zero;
        }
    }
}