using System;
using System.Collections.Generic;
using Game.Content.Environment;
using Game.Core;
using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Controllers.Environment
{
    public class TransporterCollisionsController : MonoBehaviour
    {
        private readonly Dictionary<ISpawnable, IMovable> _spawnableTargets = new();

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
                    _transporter.AddTarget(target);

                    if (entity.TryGet(out ISpawnable spawnableObject))
                        AddSpawnableObject(spawnableObject, target);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out ISpawnable spawnableObject))
                    RemoveSpawnableObject(spawnableObject);
                else if (entity.TryGet(out IMovable target))
                    _transporter.RemoveTarget(target);
            }
        }

        private void AddSpawnableObject(ISpawnable spawnableObject, IMovable target)
        {
            _spawnableTargets.Add(spawnableObject, target);

            spawnableObject.Removed += RemoveSpawnableObject;
        }

        private void RemoveSpawnableObject(ISpawnable spawnableObject)
        {
            if (_spawnableTargets.Remove(spawnableObject, out IMovable movable))
            {
                _transporter.RemoveTarget(movable);
                spawnableObject.Removed -= RemoveSpawnableObject;
            }
        }
    }
}