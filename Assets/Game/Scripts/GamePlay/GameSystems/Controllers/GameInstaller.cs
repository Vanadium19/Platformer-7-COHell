using Game.Content.Environment;
using Game.Content.Player;
using Game.Core;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Controllers
{
    public class GameInstaller : MonoInstaller
    {
        private const string BoxName = "Box";

        [SerializeField] private Entity _player;

        [Header("Box Spawner")]
        [SerializeField] private BoxSpawnerParams[] _boxSpawnerParams;
        [SerializeField] private Transform _boxesContainer;
        [SerializeField] private Entity _boxPrefab;

        public override void InstallBindings()
        {
            Container.Bind<CharacterProvider>()
                .AsSingle()
                .WithArguments(_player);

            Container.BindInterfacesAndSelfTo<LevelController>()
                .AsSingle()
                .NonLazy();

            Container.BindMemoryPool<Entity, BoxPool>()
                .ExpandByOneAtATime()
                .FromComponentInNewPrefab(_boxPrefab)
                .WithGameObjectName(BoxName)
                .UnderTransform(_boxesContainer)
                .AsSingle();

            foreach (var spawnerParams in _boxSpawnerParams)
            {
                Container.BindInterfacesTo<BoxSpawner>()
                    .AsCached()
                    .WithArguments(spawnerParams);
            }
        }
    }
}