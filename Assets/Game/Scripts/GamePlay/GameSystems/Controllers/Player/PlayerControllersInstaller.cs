using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class PlayerControllersInstaller : MonoInstaller
    {
        [SerializeField] private PlayerCollisionsController _collisionsController;

        [Header("Settings")] [SerializeField] private float _sensitivity = 1.2f;
        [SerializeField] private float _verticalMinAngle = 10f;
        [SerializeField] private float _verticalMaxAngle = 45f;

        public override void InstallBindings()
        {
            Container.Bind<PlayerCollisionsController>()
                .FromInstance(_collisionsController)
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<PlayerMoveController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<PlayerRotationController>()
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