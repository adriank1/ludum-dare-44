using UnityEngine;

namespace AdrianKovatana
{
    public class PlayScreen : MonoBehaviour
    {
        public MusicClipData musicClip;

        private void Start()
        {
            musicClip?.Play();
        }

        private void OnDisable()
        {
            AudioManager.Instance.StopMusic();
        }
    }
}
