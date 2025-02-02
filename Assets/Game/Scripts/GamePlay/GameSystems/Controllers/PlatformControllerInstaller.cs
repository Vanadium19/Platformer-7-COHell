using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class PlatformControllerInstaller : MonoInstaller
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PointsMoveController>()
                .AsSingle()
                .WithArguments(_startPoint.position, _endPoint.position)
                .NonLazy();
        }
    }
}