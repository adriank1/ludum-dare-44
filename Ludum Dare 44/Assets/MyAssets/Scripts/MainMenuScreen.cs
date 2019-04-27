using UnityEngine;

namespace AdrianKovatana
{
    public class MainMenuScreen : MonoBehaviour
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
