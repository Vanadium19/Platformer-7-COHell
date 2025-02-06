using Game.Core.Components;
using Game.View;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Content.Player
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private CollisionReceiver _platformTracker;

        [Header("Health Settings")] [SerializeField] private int _maxHealth = 10;

        [Header("Move Settings")] [SerializeField] private float _speed = 3f;

        [Header("Rotation Settings")] [SerializeField] private float _sensitivity = 5f;

        [Header("Jump Settings")] [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private float _extraJumpForce = 3f;
        [SerializeField] private float _jumpDelay = 1f;
        [SerializeField] private GroundCheckParams _groundCheckParams;

        [Header("View Settings")] [SerializeField] private PlayerView _playerView;

        public override void InstallBindings()
        {
            //Main
            Container.BindInterfacesAndSelfTo<Character>()
                .AsSingle()
                .NonLazy();

            //MonoBehaviors
            Container.Bind<Rigidbody>()
                .FromInstance(_rigidbody)
                .AsSingle();

            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsSingle();

            //Components
            Container.Bind<MoveComponent>()
                .AsSingle()
                .WithArguments(_speed);

            Container.BindInterfacesAndSelfTo<JumpComponent>()
                .AsSingle()
                .WithArguments(_jumpForce, _extraJumpForce, _jumpDelay);

            Container.BindInterfacesTo<RotationComponent>()
                .AsSingle()
                .WithArguments(_sensitivity);

            Container.BindInterfacesAndSelfTo<GroundChecker>()
                .AsSingle()
                .WithArguments(_groundCheckParams, _platformTracker);

            Container.BindInterfacesAndSelfTo<HealthComponent>()
                .AsSingle()
                .WithArguments(_maxHealth);

            Container.BindInterfacesAndSelfTo<InteractionComponent>()
                .AsSingle();

            //Presenter
            Container.BindInterfacesTo<PlayerPresenter>()
                .AsSingle()
                .NonLazy();

            //View
            Container.Bind<PlayerView>()
                .FromInstance(_playerView)
                .AsSingle();
        }

        #region Debug

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            //Jump
            if (_groundCheckParams.Point == null)
                return;

            Gizmos.DrawWireCube(_groundCheckParams.Point.position, _groundCheckParams.OverlapSize);
        }

        #endregion
    }
}