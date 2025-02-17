using System.Collections.Generic;
using Game.Core;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class BoxSpawner : ITickable
    {
        private readonly BoxPool _pool;
        private readonly Vector3 _position;
        private readonly float _delay;

        private readonly Dictionary<ISpawnable, Entity> _boxes = new();

        private float _currentTime;

        public BoxSpawner(BoxPool pool, BoxSpawnerParams spawnerParams)
        {
            _pool = pool;
            _position = spawnerParams.Position;
            _delay = spawnerParams.Delay;
        }

        public void Tick()
        {
            _currentTime -= Time.deltaTime;
        
            if (_currentTime <= 0)
                Spawn();
        }

        private void Spawn()
        {
            Entity entity = _pool.Spawn(_position);
            Box box = entity.Get<Box>();

            _boxes[box] = entity;
            box.Removed += Despawn;

            _currentTime = _delay;
        }

        private void Despawn(ISpawnable box)
        {
            if (_boxes.Remove(box, out Entity entity))
            {
                _pool.Despawn(entity);
                box.Removed -= Despawn;
            }
        }
    }
}