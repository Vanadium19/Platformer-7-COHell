using System;
using UnityEngine;

namespace Game.Content.Environment
{
    public class Box
    {
        public event Action<Box> Removed;

        public void Remove()
        {
            Removed?.Invoke(this);
        }
    }
}