using UnityEngine;
using Zenject;

namespace Game.Menu.Core
{
    [CreateAssetMenu(
        fileName = "MenuInstaller",
        menuName = "Zenject/New MenuInstaller"
    )]
    public class MenuInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MenuFacade>()
                .AsCached()
                .NonLazy();

            Container.BindInterfacesTo<GameSettings>()
                .AsSingle()
                .NonLazy();
        }
    }
}