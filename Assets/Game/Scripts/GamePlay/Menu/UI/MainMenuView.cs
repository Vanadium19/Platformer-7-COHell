using System;
using Game.Menu.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Menu.UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        private MenuFacade _menu;

        [Inject]
        private void Construct(MenuFacade menu)
        {
            _menu = menu;
        }

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayClicked);
            _exitButton.onClick.AddListener(OnExitClicked);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayClicked);
            _exitButton.onClick.RemoveListener(OnExitClicked);
        }

        private void OnPlayClicked()
        {
            _menu.LoadGame();
        }

        private void OnExitClicked()
        {
            _menu.ExitGame();
        }
    }
}