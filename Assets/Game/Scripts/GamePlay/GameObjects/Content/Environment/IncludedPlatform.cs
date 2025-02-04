using System;
using Cysharp.Threading.Tasks;
using Game.Core;
using Game.Core.Components;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class IncludedPlatform : IInitializable, IDisposable, Iinteractable
    {
        private readonly TriggerReceiver _triggerReceiver;
        private readonly GameObject _platform;
        private readonly float _delay;

        private readonly ReactiveCommand<Action> _platformEnabled = new();

        private bool _isActive;

        public IncludedPlatform(TriggerReceiver triggerReceiver, GameObject platform, float delay)
        {
            _triggerReceiver = triggerReceiver;
            _platform = platform;
            _delay = delay;
        }

        public IObservable<Action> PlatformEnabled => _platformEnabled;

        public void Initialize()
        {
            _triggerReceiver.Entered += OnEntered;
            _triggerReceiver.Exited += OnExited;
        }

        public void Dispose()
        {
            _triggerReceiver.Entered -= OnEntered;
            _triggerReceiver.Exited -= OnExited;
        }

        public void Interact()
        {
            if (_isActive)
                return;

            _platformEnabled.Execute(() => EnablePlatform().Forget());
        }

        private async UniTask EnablePlatform()
        {
            _isActive = true;
            _platform.SetActive(true);

            await UniTask.Delay(TimeSpan.FromSeconds(_delay));

            _platform.SetActive(false);
            _isActive = false;
        }

        private void OnEntered(Collider target)
        {
            if (target.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out IInteractionList player))
                {
                    player.AddInteractable(this);
                }
            }
        }

        private void OnExited(Collider target)
        {
            if (target.TryGetComponent(out IEntity entity))
            {
                if (entity.TryGet(out IInteractionList player))
                {
                    player.RemoveInteractable(this);
                }
            }
        }
    }
}