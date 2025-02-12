using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class KeyboardMenuController : ITickable
    {
        private readonly ReactiveCommand _menuOpened = new();

        public IObservable<Unit> OnMenuOpened => _menuOpened;

        public void Tick()
        {
            if (Time.timeScale == 0)
                return;

            if (Input.GetKeyDown(KeyCode.Escape))
                _menuOpened.Execute();
        }
    }
}