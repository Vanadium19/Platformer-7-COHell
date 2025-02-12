using Game.Content.Player;
using Game.Core;
using UnityEngine;

namespace Game.Content.Triggers
{
    public class CheckPoint : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out Character target))
                {
                    target.SetSpawnPosition(_spawnPoint.position);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}