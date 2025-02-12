using Game.Core;
using Game.Core.Components;
using UnityEngine;

namespace Game.Content.Triggers
{
    public class DeadZone : MonoBehaviour
    {
        private readonly int _damage = int.MaxValue;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Entered DeadZone");
            
            if (other.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out IDamagable target))
                {
                    target.TakeDamage(_damage);
                }
            }
        }
    }
}