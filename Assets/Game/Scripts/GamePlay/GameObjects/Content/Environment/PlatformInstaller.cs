using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class PlatformInstaller : MonoInstaller
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody _rigidbody;

        [Header("Move Settings")] [SerializeField] private float _speed = 3f;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Platform>()
                .AsSingle()
                .NonLazy();

            Container.Bind<Rigidbody>()
                .FromInstance(_rigidbody)
                .AsSingle();

            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsSingle();

            Container.Bind<TransformMoveComponent>()
                .AsSingle()
                .WithArguments(_speed);
        }
    }
}