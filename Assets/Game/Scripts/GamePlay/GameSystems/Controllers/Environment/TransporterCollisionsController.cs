using System;
using Game.Content.Environment;
using Game.Core;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Controllers.Environment
{
    public class TransporterCollisionsController : MonoBehaviour
    {
        private Transporter _transporter;

        [Inject]
        public void Construct(Transporter transporter)
        {
            _transporter = transporter;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out IMovable target))
                {
                    // Debug.Log("Entered Transporter Collision Controller");
                    
                    _transporter.AddTarget(target);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out IMovable target))
                {
                    // Debug.Log("Exited Transporter Collision Controller");
                    
                    _transporter.RemoveTarget(target);
                }
            }
        }
    }
}