using System.Collections;
using UnityEngine;

namespace AdrianKovatana
{
    public class MusicSourceController : PooledObject
    {
#pragma warning disable
        [SerializeField]
        private AudioSource _audioSourceIntro;

        [SerializeField]
        private AudioSource _audioSourceLoop;
#pragma warning restore

        private MusicClipData _musicClipData;
        private bool _hasIntro;

        public void Init(MusicClipData data, bool loop)
        {
            //reset
            _audioSourceIntro.volume = 1f;
            _audioSourceLoop.volume = 1f;
            _hasIntro = false;
            _musicClipData = null;

            _audioSourceLoop.outputAudioMixerGroup = data.mixerGroup;
            if(data.intro != null)
            {
                _hasIntro = true;
                _audioSourceIntro.clip = data.intro;
            }
            _audioSourceLoop.clip = data.clip;
            _audioSourceLoop.loop = loop;
            _musicClipData = data;
        }

        public void Play()
        {
            if(_audioSourceLoop.outputAudioMixerGroup != null && _audioSourceLoop.clip != null)
            {
                if(_hasIntro)
                {
                    _audioSourceIntro.Play();
                    _audioSourceLoop.PlayScheduled(AudioSettings.dspTime + _musicClipData.intro.length);
                }
                else
                {
                    _audioSourceLoop.Play();
                }
            }
            else
            {
                Debug.LogWarning(name + " was not initialized with audio data");
            }
        }

        public void Play(MusicClipData data, bool loop)
        {
            Init(data, loop);
            Play();
        }

        public void Stop()
        {
            _audioSourceIntro.Stop();
            _audioSourceLoop.Stop();
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

            while(_audioSourceLoop.volume > 0)
            {
                _audioSourceIntro.volume -= Time.deltaTime / fadeDuration;
                _audioSourceLoop.volume -= Time.deltaTime / fadeDuration;

                yield return null;
            }

            Stop();
            ReturnToPool();
        }

        private IEnumerator FadeInCoroutine(float fadeDuration)
        {
            //Let current frame finish
            yield return null;

            _audioSourceIntro.volume = 0f;
            _audioSourceLoop.volume = 0f;
            Play();

            while(_audioSourceLoop.volume < 1)
            {
                _audioSourceIntro.volume += Time.deltaTime / fadeDuration;
                _audioSourceLoop.volume += Time.deltaTime / fadeDuration;

                yield return null;
            }
        }
    }
}
