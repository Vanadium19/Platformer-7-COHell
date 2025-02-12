using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Menu.UI
{
    public class GameSettingsView : MonoBehaviour
    {
        [SerializeField] private Slider _volumeSlider;

        private readonly ReactiveProperty<float> _volume = new();

        public IReadOnlyReactiveProperty<float> Volume => _volume;

        private void OnEnable()
        {
            _volumeSlider.onValueChanged.AddListener(OnValueChanged);
        }

        private void Start()
        {
            _volumeSlider.value = AudioListener.volume;
        }

        private void OnDisable()
        {
            _volumeSlider.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(float volume)
        {
            _volume.Value = volume;
        }

        #region Debug

        [ContextMenu(nameof(CheckVolume))]
        public void CheckVolume()
        {
            Debug.Log("Volume: " + AudioListener.volume);
        }

        #endregion
    }
}