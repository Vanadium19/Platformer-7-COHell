using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Player
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private Rigidbody _rigidbody;

        [Header("Move Settings")] [SerializeField] private float _speed;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Character>()
                .AsSingle()
                .NonLazy();

            Container.Bind<Rigidbody>()
                .FromInstance(_rigidbody)
                .AsSingle();

            Container.Bind<MoveComponent>()
                .AsSingle()
                .WithArguments(_speed);
        }
    }
}