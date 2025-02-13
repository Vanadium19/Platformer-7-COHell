using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class BoxInstaller : MonoInstaller
    {
        private const float Speed = 0f;

        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody _rigidbody;

        public override void InstallBindings()
        {
            //MonoBehaviors
            Container.Bind<Rigidbody>()
                .FromInstance(_rigidbody)
                .AsSingle();

            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsSingle();

            //Comonents
            Container.BindInterfacesAndSelfTo<MoveComponent>()
                .AsSingle()
                .WithArguments(Speed)
                .NonLazy();
        }
    }
}