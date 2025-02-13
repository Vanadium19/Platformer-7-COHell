using System;
using Game.Content.Environment;
using Game.Content.Player;
using Game.Core;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class PlayerCollisionsController : MonoBehaviour
    {
        private Character _player;

        [Inject]
        public void Construct(Character player)
        {
            _player = player;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.gameObject.name);

            if (collision.collider.TryGetComponent(out IEntity entity) && CheckNormal(collision))
            {
                if (entity.TryGet(out Platform platform))
                {
                    _player.SetParent(collision.collider.transform);
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out Platform platform))
                {
                    _player.SetParent(null);
                }
            }
        }

        private bool CheckNormal(Collision target)
        {
            foreach (var contact in target.contacts)
            {
                if (contact.normal == Vector3.up)
                    return true;
            }

            return false;
        }
    }
}