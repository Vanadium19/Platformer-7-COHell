using Game.Content.Environment;
using Game.Content.Player;
using Game.Core;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class PlayerCollisionsController : MonoBehaviour
    {
        private Character _player;
        private IInteractionList _interactionList;

        [Inject]
        public void Construct(Character player, IInteractionList interactionList)
        {
            _player = player;
            _interactionList = interactionList;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IEntity entity) && CheckNormal(collision))
            {
                if (entity.TryGet(out Platform platform))
                    _player.SetParent(collision.collider.transform);
                else if (entity.TryGet(out Box box))
                    _player.SetParent(collision.collider.transform, entity.Get<Rigidbody>());
            }
            else if(collision.collider.TryGetComponent(out ResponsivePlatform responsivePlatform) && CheckNormal(collision))
            {
                _player.SetParent(collision.collider.transform);
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out IInteraction interaction))
                {
                    _interactionList.AddInteractable(interaction);
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out Platform platform) || entity.TryGet(out Box box))
                {
                    _player.SetParent(null);
                }
            }
            else if (collision.collider.TryGetComponent(out ResponsivePlatform responsivePlatform))
            {
                _player.SetParent(null);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out IInteraction interaction))
                {
                    _interactionList.RemoveInteractable(interaction);
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