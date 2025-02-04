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
        [SerializeField] private float _sensitivity = 1.2f;
        [SerializeField] private float _verticalMinAngle = 10f;
        [SerializeField] private float _verticalMaxAngle = 45f;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerMoveController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<PlayerJumpController>()
                .AsSingle()
                .NonLazy();
            
            Container.BindInterfacesTo<PlayerInteractionController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<CameraController>()
                .AsSingle()
                .WithArguments(_sensitivity, _verticalMinAngle, _verticalMaxAngle)
                .NonLazy();
        }
    }
}