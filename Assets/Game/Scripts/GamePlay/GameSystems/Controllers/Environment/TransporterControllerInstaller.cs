using UnityEngine;
using Zenject;

namespace Game.Controllers.Environment
{
    public class TransporterControllerInstaller : MonoInstaller
    {
        [SerializeField] private TransporterCollisionsController _controller;

        public override void InstallBindings()
        {
            Container.Bind<TransporterCollisionsController>()
                .FromInstance(_controller)
                .AsSingle()
                .NonLazy();
        }
    }
}