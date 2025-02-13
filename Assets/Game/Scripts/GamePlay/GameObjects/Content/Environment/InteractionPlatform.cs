using System;
using Cysharp.Threading.Tasks;
using Game.Core;
using Game.Core.Components;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Content.Environment
{
    public class InteractionPlatform : IInteraction
    {
        private readonly DelayedPatrolComponent _patrolComponent;

        private readonly ReactiveCommand<Action> _platformEnabled = new();

        private bool _isActive;

        public InteractionPlatform(DelayedPatrolComponent patrolComponent)
        {
            _patrolComponent = patrolComponent;
        }

        public IObservable<Action> PlatformEnabled => _platformEnabled;

        public void Interact()
        {
            if (_isActive)
                return;

            _isActive = true;
            _patrolComponent.Returned += OnPlatformReturned;
            _platformEnabled.Execute(() => _patrolComponent.Activate());
        }

        private void OnPlatformReturned()
        {
            _isActive = false;
            _patrolComponent.Returned -= OnPlatformReturned;
        }
    }
}