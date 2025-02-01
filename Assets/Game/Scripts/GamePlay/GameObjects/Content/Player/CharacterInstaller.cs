using Game.Core.Components;
using UnityEngine;
using Zenject;

namespace Game.Content.Player
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private Rigidbody _rigidbody;

        [Header("Move Settings")] [SerializeField] private float _speed = 3f;

        [Header("Jump Settings")] [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private float _extraJumpForce = 3f;
        [SerializeField] private float _jumpDelay = 1f;
        [SerializeField] private GroundCheckParams _groundCheckParams;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Character>()
                .AsSingle()
                .NonLazy();

            Container.Bind<Rigidbody>()
                .FromInstance(_rigidbody)
                .AsSingle();

            Container.Bind<MoveComponent>()
                .AsSingle()
                .WithArguments(_speed);

            Container.BindInterfacesAndSelfTo<JumpComponent>()
                .AsSingle()
                .WithArguments(_jumpForce, _extraJumpForce, _jumpDelay);

            Container.Bind<GroundChecker>()
                .AsSingle()
                .WithArguments(_groundCheckParams);
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