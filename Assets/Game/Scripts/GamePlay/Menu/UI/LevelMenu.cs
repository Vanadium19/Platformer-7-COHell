using System;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game.Menu.UI
{
    public class LevelMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPopup;
        [SerializeField] private Button _restartButton;

        [SerializeField] private Button _openButton;
        [SerializeField] private Button _continueButton;
        [SerializeField] private GameObject _menuPopup;

        [SerializeField] private Button[] _exitButtons;

        private readonly CompositeDisposable _disposable = new();
        private readonly ReactiveCommand _restartCommand = new();
        private readonly ReactiveCommand _openMenuCommand = new();
        private readonly ReactiveCommand _continueCommand = new();
        private readonly ReactiveCommand _exitCommand = new();

        public IObservable<Unit> LevelRestarted => _restartCommand;
        public IObservable<Unit> MenuOpened => _openMenuCommand;
        public IObservable<Unit> Continued => _continueCommand;
        public IObservable<Unit> Exited => _exitCommand;

        private void OnEnable()
        {
            _restartCommand.BindTo(_restartButton).AddTo(_disposable);
            _restartCommand.BindTo(_restartButton).AddTo(_disposable);

            _openMenuCommand.BindToOnClick(_openButton, _ => EnableMenu(true)).AddTo(_disposable);
            _continueCommand.BindToOnClick(_continueButton, _ => EnableMenu(false)).AddTo(_disposable);

            foreach (var button in _exitButtons)
                _exitCommand.BindTo(button).AddTo(_disposable);
        }

        private void OnDisable()
        {
            _disposable.Clear();
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }

        public void EnableMenu(bool value)
        {
            _menuPopup.SetActive(value);
        }

        public void EnableGameOverPopup(bool value)
        {
            _gameOverPopup.SetActive(value);
        }
    }
}