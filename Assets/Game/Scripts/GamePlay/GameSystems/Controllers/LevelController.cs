using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Content.Player;
using Game.Core.Components;
using UniRx;
using Zenject;

namespace Game.Controllers
{
    public class LevelController : IInitializable, IDisposable
    {
        private const float LevelRestartDelay = 2f;

        private readonly CharacterProvider _player;

        private readonly CompositeDisposable _disposables = new();
        private readonly ReactiveCommand _levelLost = new();

        public LevelController(CharacterProvider player)
        {
            _player = player;
        }

        public IObservable<Unit> LevelLost => _levelLost;

        public void Initialize()
        {
            _player.Get<IDamagable>().Died.Subscribe(_ => OnPlayerDied()).AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        private void OnPlayerDied()
        {
            RestartLevelAsync().Forget();
        }

        private async UniTaskVoid RestartLevelAsync()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(LevelRestartDelay));
            
            _player.Get<Character>().ResetPlayer();
            _levelLost.Execute();
        }
    }
}