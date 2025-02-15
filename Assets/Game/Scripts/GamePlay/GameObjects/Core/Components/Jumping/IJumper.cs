using System;
using UniRx;

namespace Game.Core.Components
{
    public interface IJumper
    {
        public IObservable<Unit> Jumped { get; }

        public bool Jump();
        public void AddExtraForce(float multiplier);
    }
}