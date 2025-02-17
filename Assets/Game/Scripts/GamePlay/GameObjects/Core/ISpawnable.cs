using System;

namespace Game.Core
{
    public interface ISpawnable
    {
        public event Action<ISpawnable> Removed;

        public void Remove();
    }
}