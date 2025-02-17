using System;
using Game.Core;

namespace Game.Content.Environment
{
    public class Box : ISpawnable
    {
        public event Action<ISpawnable> Removed;

        public void Remove()
        {
            Removed?.Invoke(this);
        }
    }
}