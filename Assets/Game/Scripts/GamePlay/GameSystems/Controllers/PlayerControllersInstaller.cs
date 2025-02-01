using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    [CreateAssetMenu(
        fileName = "PlayerControllersInstaller",
        menuName = "Zenject/New PlayerControllersInstaller"
    )]
    public class PlayerControllersInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerMoveController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<PlayerJumpController>()
                .AsSingle()
                .NonLazy();
        }
    }
}