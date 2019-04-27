using UnityEngine;

namespace AdrianKovatana
{
    [CreateAssetMenu(menuName = "Data/Audio/MixerGroupVolume")]
    public class MixerGroupVolumeData : ScriptableObject
    {
#pragma warning disable
        [SerializeField]
        private string _exposedParameter;
#pragma warning restore
        public string ExposedParameter
        {
            get { return _exposedParameter; }
        }
        
        [Range(-80f, 0f)]
        public float volume = 0f;

        public void UpdateVolume(float value)
        {
            volume = value;
            AudioManager.Instance.UpdateVolume(_exposedParameter, volume);
        }
    }
}
