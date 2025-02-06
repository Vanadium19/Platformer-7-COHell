using System;
using Cysharp.Threading.Tasks;
using Game.Core;
using Game.Core.Components;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class IncludedPlatform : IInitializable, IDisposable, IInteraction
    {
        private readonly TriggerReceiver _triggerReceiver;
        private readonly DelayedPatrolComponent _patrolComponent;

        private readonly ReactiveCommand<Action> _platformEnabled = new();
        
        private bool _isActive;

        public IncludedPlatform(TriggerReceiver triggerReceiver, DelayedPatrolComponent patrolComponent)
        {
            _triggerReceiver = triggerReceiver;
            _patrolComponent = patrolComponent;
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

            _isActive = true;
            _patrolComponent.Returned += OnPlatformReturned;
            _platformEnabled.Execute(() => _patrolComponent.Activate());
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

        private void OnPlatformReturned()
        {
            _isActive = false;
            _patrolComponent.Returned -= OnPlatformReturned;
        }
    }
}