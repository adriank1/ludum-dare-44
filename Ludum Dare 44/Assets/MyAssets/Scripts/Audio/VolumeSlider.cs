using UnityEngine;
using UnityEngine.UI;

namespace AdrianKovatana
{
    public class VolumeSlider : MonoBehaviour
    {
        private Slider _slider;

#pragma warning disable
        [SerializeField]
        private MixerGroupVolumeData _audioSettings;
#pragma warning restore

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            _slider.value = _audioSettings.volume;
        }

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(delegate { _audioSettings.UpdateVolume(_slider.value); });
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(delegate { _audioSettings.UpdateVolume(_slider.value); });
        }
    }
}
