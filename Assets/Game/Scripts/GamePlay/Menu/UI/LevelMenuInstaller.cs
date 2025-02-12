using UnityEngine;
using Zenject;

namespace Game.Menu.UI
{
    public class LevelMenuInstaller : MonoInstaller
    {
        [SerializeField] private LevelMenu _levelMenu;
        [SerializeField] private GameSettingsView _gameSettingsView;

        public override void InstallBindings()
        {
            Container.Bind<LevelMenu>()
                .FromInstance(_levelMenu)
                .AsSingle();

            Container.BindInterfacesTo<LevelMenuPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<GameSettingsView>()
                .FromInstance(_gameSettingsView)
                .AsSingle();

            Container.BindInterfacesTo<GameSettingsPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}