using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class PlatformInstaller : MonoInstaller
    {
        [SerializeField] private Transform _transform;

        [Header("Move Settings")] [SerializeField] private float _speed = 3f;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;

        public override void InstallBindings()
        {
            Container.Bind<Platform>()
                .AsSingle()
                .NonLazy();

            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsSingle();

            Container.BindInterfacesTo<PatrolComponent>()
                .AsSingle()
                .WithArguments(_startPoint.position, _endPoint.position, _speed);
        }
    }
}