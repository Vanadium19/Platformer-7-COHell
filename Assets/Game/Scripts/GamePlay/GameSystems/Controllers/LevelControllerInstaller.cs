using Game.Content.Player;
using Game.Core;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class LevelControllerInstaller : MonoInstaller
    {
        [SerializeField] private Entity _player;

        public override void InstallBindings()
        {
            Container.Bind<CharacterProvider>()
                .AsSingle()
                .WithArguments(_player);

            Container.BindInterfacesAndSelfTo<LevelController>()
                .AsSingle()
                .NonLazy();
        }
    }
}