using UnityEngine;
using UnityEngine.Audio;

namespace AdrianKovatana
{
    [CreateAssetMenu(menuName = "Data/Audio/AudioClip")]
    public class AudioClipData : ScriptableObject
    {
        public AudioMixerGroup mixerGroup;
        public AudioClip clip;

        public virtual void Play()
        {
            if(clip != null)
            {
                AudioManager.Instance.PlayClipFromData(this);
            }
        }
    }
}
