using System;
using UniRx;
using UnityEngine;

namespace Game.Core.Components
{
    public class HealthComponent : IDamagable
    {
        private readonly int _maxHealth;

        private readonly ReactiveProperty<int> _currentHealth = new();
        private readonly ReactiveCommand _died = new();

        public HealthComponent(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth.Value = maxHealth;
        }

        public IReadOnlyReactiveProperty<int> CurrentHealth => _currentHealth;
        public IObservable<Unit> Died => _died;

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
                return;

            if (_currentHealth.Value <= 0)
                return;

            _currentHealth.Value = Mathf.Max(0, _currentHealth.Value - damage);

            if (_currentHealth.Value <= 0)
                _died.Execute();
        }

        public void ResetHealth()
        {
            _currentHealth.Value = _maxHealth;
        }
    }
}