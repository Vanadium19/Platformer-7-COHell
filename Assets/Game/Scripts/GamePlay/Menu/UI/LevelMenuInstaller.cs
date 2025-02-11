using UnityEngine;
using Zenject;

namespace Game.Menu.UI
{
    public class LevelMenuInstaller : MonoInstaller
    {
        [SerializeField] private LevelMenu _levelMenu;

        public override void InstallBindings()
        {
            Container.Bind<LevelMenu>()
                .FromInstance(_levelMenu)
                .AsSingle();

            Container.BindInterfacesTo<LevelMenuPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}