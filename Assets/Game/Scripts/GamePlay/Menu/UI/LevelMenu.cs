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

        [SerializeField] private Button[] _exitButtons;

        private readonly CompositeDisposable _disposable = new();
        private readonly ReactiveCommand _restartCommand = new();
        private readonly ReactiveCommand _exitCommand = new();

        public IObservable<Unit> LevelRestarted => _restartCommand;
        public IObservable<Unit> Exited => _exitCommand;

        private void OnEnable()
        {
            _restartCommand.BindTo(_restartButton).AddTo(_disposable);

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

        public void EnableGameOverPopup(bool value)
        {
            _gameOverPopup.SetActive(value);
        }
    }
}