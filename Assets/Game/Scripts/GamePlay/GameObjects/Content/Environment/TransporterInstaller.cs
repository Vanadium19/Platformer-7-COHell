using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class TransporterInstaller : MonoInstaller
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private TriggerReceiver _playerTracker;
        [SerializeField] private float _speed;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Transporter>()
                .AsSingle()
                .WithArguments(_playerTracker, _speed)
                .NonLazy();

            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsSingle();
        }
    }
}