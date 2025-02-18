using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Menu.UI
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuView _menuView;
        [SerializeField] private GameSettingsView _settingsView;


        public override void InstallBindings()
        {
            Container.Bind<MainMenuView>()
                .FromInstance(_menuView)
                .AsSingle();

            Container.BindInterfacesTo<MainMenuPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<GameSettingsView>()
                .FromInstance(_settingsView)
                .AsSingle();

            Container.BindInterfacesTo<GameSettingsPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}