using System;
using UniRx;

namespace Game.Core.Components
{
    public interface IDamagable
    {
        public bool IsDead { get; }
        public IObservable<Unit> Died { get; }
        
        public void TakeDamage(int damage);
    }
}