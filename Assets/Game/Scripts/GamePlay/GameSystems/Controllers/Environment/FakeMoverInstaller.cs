using Game.Controllers;
using UnityEngine;
using Zenject;

namespace Game.Scripts.GamePlay.GameSystems.Controllers.Environment
{
    [CreateAssetMenu(
        fileName = "FakeMoverInstaller",
        menuName = "Zenject/New FakeMoverInstaller"
    )]
    public class FakeMoverInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<FakeMover>()
                .AsSingle()
                .NonLazy();
        }
    }
}