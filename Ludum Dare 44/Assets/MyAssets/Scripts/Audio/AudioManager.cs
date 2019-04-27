using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace AdrianKovatana
{
    public class AudioManager : MonoBehaviour
    {
        //Singleton requirements
        protected AudioManager() { } // guarantee this will be always a singleton only - can't use the constructor!
        public static AudioManager Instance { get; private set; }

        //Components
        private MusicSourceController _audioSourceMusic;

#pragma warning disable
        [SerializeField]
        private ObjectPool _musicSourcePool;

        [SerializeField]
        private ObjectPool _audioSourcePool;

        //Data
        [SerializeField]
        private AudioMixer _audioMixer;
#pragma warning restore

        public List<MixerGroupVolumeData> volumeData;

        public float musicFadeOutDuration = 1f;
        public float musicFadeInDuration = 1f;

        private void Awake()
        {
            //Singleton requirements
            if(Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                Instance = this;
            }

            //Persist through scene changes
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            foreach(MixerGroupVolumeData data in volumeData)
            {
                _audioMixer.SetFloat(data.ExposedParameter, data.volume);
            }
        }

        public void PlayMusic(MusicClipData data)
        {
            _audioSourceMusic =
                _musicSourcePool.GetObject().GetComponent<MusicSourceController>();
            _audioSourceMusic.Init(data, true);
            if(musicFadeInDuration > 0f)
            {
                _audioSourceMusic.FadeIn(musicFadeInDuration);
            }
            else
            {
                _audioSourceMusic.Play();
            }
        }

        public void StopMusic()
        {
            if(_audioSourceMusic)
            {
                _audioSourceMusic.FadeOut(musicFadeOutDuration);
            }
        }

        public void PlayClipFromData(AudioClipData data)
        {
            _audioSourcePool.GetObject()
                .GetComponent<AudioSourceController>()
                .Play(data, false);
        }
        
        public void UpdateVolume(string name, float value)
        {
            _audioMixer.SetFloat(name, value);
        }
    }
}