using UnityEngine;
using Zenject;

namespace Game.Menu.Core
{
    public class GameSettings : IInitializable, IGameSettings
    {
        private float _volume = 0.7f;

        public float Volume => _volume;

        public void Initialize()
        {
            Debug.Log("Game settings initialized");
            AudioListener.volume = _volume;
        }

        public void SetVolume(float volume)
        {
            _volume = volume;
            AudioListener.volume = volume;
        }
    }
}