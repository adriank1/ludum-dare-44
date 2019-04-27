using System.Collections;
using UnityEngine;

namespace AdrianKovatana
{
    public class AudioSourceController : PooledObject
    {
        private AudioSource _audioSource;
        private bool _startedPlaying;

        private void Awake()
        {
            OnAwake();
            _audioSource = GetComponent<AudioSource>();
            _startedPlaying = false;
        }

        private void Update()
        {
            if(_startedPlaying && !_audioSource.isPlaying)
            {
                BackToPool();
            }
        }

        public void Init(AudioClipData data, bool loop)
        {
            _audioSource.outputAudioMixerGroup = data.mixerGroup;
            _audioSource.clip = data.clip;
            _audioSource.loop = loop;
        }

        public void BackToPool()
        {
            _startedPlaying = false;
            _audioSource.volume = 1f;
            ReturnToPool();
        }

        public void Play()
        {
            if(_audioSource.outputAudioMixerGroup != null && _audioSource.clip != null)
            {
                _audioSource.Play();
                _startedPlaying = true;
            }
            else
            {
                Debug.LogWarning(name + " was not initialized with audio data");
            }
        }

        public void Play(AudioClipData data, bool loop)
        {
            Init(data, loop);
            Play();
        }

        public void Stop()
        {
            _audioSource.Stop();
        }

        public void Pause()
        {
            _audioSource.Pause();
        }

        public void UnPause()
        {
            _audioSource.UnPause();
        }

        public void FadeOut(float fadeDuration)
        {
            StopAllCoroutines();
            StartCoroutine(FadeOutCoroutine(fadeDuration));
        }

        public void FadeIn(float fadeDuration)
        {
            StopAllCoroutines();
            StartCoroutine(FadeInCoroutine(fadeDuration));
        }

        private IEnumerator FadeOutCoroutine(float fadeDuration)
        {
            //Let current frame finish
            yield return null;

            while(_audioSource.volume > 0)
            {
                _audioSource.volume -= Time.deltaTime / fadeDuration;

                yield return null;
            }

            _audioSource.Stop();
            BackToPool();
        }

        private IEnumerator FadeInCoroutine(float fadeDuration)
        {
            //Let current frame finish
            yield return null;

            _audioSource.volume = 0f;
            _audioSource.Play();

            while(_audioSource.volume < 1)
            {
                _audioSource.volume += Time.deltaTime / fadeDuration;

                yield return null;
            }
        }
    }
}
