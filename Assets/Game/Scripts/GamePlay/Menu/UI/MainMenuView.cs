using System;
using Game.Menu.Core;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Menu.UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        private readonly ReactiveCommand _playCommand = new();
        private readonly ReactiveCommand _exitCommand = new();

        private readonly CompositeDisposable _disposable = new();

        public IObservable<Unit> OnPlayButtonPressed => _playCommand;
        public IObservable<Unit> OnExitButtonPressed => _exitCommand;

        private void OnEnable()
        {
            _playCommand.BindTo(_playButton).AddTo(_disposable);
            _exitCommand.BindTo(_exitButton).AddTo(_disposable);
        }

        private void OnDisable()
        {
            _disposable.Clear();
        }
    }
}