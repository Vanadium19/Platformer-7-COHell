using Game.Core.Components;
using Game.View;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class IncludedPlatformInstaller : MonoInstaller
    {
        [SerializeField] private TriggerReceiver _trigger;
        [SerializeField] private GameObject _platform;
        [SerializeField] private float _delay = 2f;

        [SerializeField] private IncludedPlatformView _view;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<IncludedPlatform>()
                .AsSingle()
                .WithArguments(_delay)
                .NonLazy();

            Container.Bind<TriggerReceiver>()
                .FromInstance(_trigger)
                .AsSingle();

            Container.Bind<GameObject>()
                .FromInstance(_platform)
                .AsSingle();

            Container.BindInterfacesTo<IncludedPlatformPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IncludedPlatformView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}