using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    [CreateAssetMenu(
        fileName = "PlayerMoveControllerInstaller",
        menuName = "Zenject/New PlayerMoveControllerInstaller"
    )]
    public class PlayerMoveControllerInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerMoveController>()
                .AsSingle()
                .NonLazy();
        }
    }
}