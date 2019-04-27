using UnityEngine;

namespace AdrianKovatana
{
    [CreateAssetMenu(menuName = "Data/Audio/MusicClip")]
    public class MusicClipData : AudioClipData
    {
        public AudioClip intro;

        public override void Play()
        {
            AudioManager.Instance.PlayMusic(this);
        }
    }
}
