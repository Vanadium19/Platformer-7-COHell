using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class TransporterInstaller : MonoInstaller
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float _speed;

        public override void InstallBindings()
        {
            //Main
            Container.BindInterfacesAndSelfTo<Transporter>()
                .AsSingle()
                .WithArguments( _speed)
                .NonLazy();

            //MonoBehaviors
            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsSingle();
        }
    }
}