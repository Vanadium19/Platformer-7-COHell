using Game.Core.Components;
using Game.View;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class IncludedPlatformInstaller : MonoInstaller
    {
        [SerializeField] private TriggerReceiver _trigger;
        [SerializeField] private Transform _platform;
        [SerializeField] private float _delay = 2f;

        [Header("Move Settings")] [SerializeField] private float _speed = 3f;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;

        [Header("View Settings")] [SerializeField] private IncludedPlatformView _view;

        public override void InstallBindings()
        {
            //Main
            Container.BindInterfacesAndSelfTo<IncludedPlatform>()
                .AsSingle()
                .NonLazy();

            //MonoBehaviors
            Container.Bind<TriggerReceiver>()
                .FromInstance(_trigger)
                .AsSingle();

            Container.Bind<Transform>()
                .FromInstance(_platform)
                .AsSingle();

            //Components
            Container.BindInterfacesAndSelfTo<DelayedPatrolComponent>()
                .AsSingle()
                .WithArguments(_startPoint.position, _endPoint.position, _speed, _delay);

            //Presenters
            Container.BindInterfacesTo<IncludedPlatformPresenter>()
                .AsSingle()
                .NonLazy();

            //View
            Container.Bind<IncludedPlatformView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}