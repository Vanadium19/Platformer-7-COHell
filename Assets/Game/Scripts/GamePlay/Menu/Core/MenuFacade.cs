using System;
using DG.Tweening;
using Game.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Menu.Core
{
    public class MenuFacade
    {
        public void LoadGame()
        {
            SceneManager.LoadScene((int)SceneNumber.Game);
        }

        public void SetVolume(float volume)
        {
            throw new NotImplementedException();
            // _gameSettings.SetVolume(volume);
            // _gameSaveLoader.Save();
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ContinueGame()
        {
            Time.timeScale = 1;
        }

        public void ReturnToMainMenu()
        {
            ContinueGame();
            SceneManager.LoadScene((int)SceneNumber.Menu);
            DOTween.KillAll();
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}