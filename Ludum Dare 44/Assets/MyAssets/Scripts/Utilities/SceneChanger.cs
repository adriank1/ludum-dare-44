using UnityEngine;
using UnityEngine.SceneManagement;

namespace AdrianKovatana
{
    public class SceneChanger : MonoBehaviour
    {
        [Range(0.1f, 5f)]
        public float fadeInDuration = 1f;
        [Range(0.1f, 5f)]
        public float fadeOutDuration = 1f;

#pragma warning disable
        [SerializeField]
        private GameEvent _onFadeInComplete;
        [SerializeField]
        private GameEvent _changeToNextScene;
#pragma warning restore

        private Animator _animator;
        private int _sceneIndex;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            Init(fadeInDuration, fadeOutDuration);
        }

        private void OnEnable()
        {
            _changeToNextScene.RegisterListener(FadeToNextScene);
        }

        private void OnDisable()
        {
            _changeToNextScene.UnregisterListener(FadeToNextScene);
        }

        private void Init(float fadeInDuration, float fadeOutDuration)
        {
            _animator.SetFloat("FadeInSpeed", 1f / fadeInDuration);
            _animator.SetFloat("FadeOutSpeed", 1f / fadeOutDuration);
        }

        public void FadeThenLoadNewScene(int sceneIndex)
        {
            _sceneIndex = sceneIndex;
            _animator.SetTrigger("FadeOut");
        }

        public void FadeToNextScene()
        {
            FadeThenLoadNewScene(
                (SceneManager.GetActiveScene().buildIndex + 1)
                % SceneManager.sceneCountInBuildSettings);
        }

        public void OnFadeOutComplete()
        {
            SceneManager.LoadScene(_sceneIndex);
        }

        public void OnFadeInCommplete()
        {
            _onFadeInComplete.Invoke();
        }
    }
}
