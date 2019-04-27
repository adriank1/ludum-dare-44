using TMPro;
using UnityEngine;

namespace AdrianKovatana
{
    public class GameTimer : MonoBehaviour
    {
#pragma warning disable
        [SerializeField]
        private TextMeshProUGUI _textHHMMSS;
        [SerializeField]
        private TextMeshProUGUI _textMilliseconds;
#pragma warning restore

        private float _currentTime;

        private void Awake()
        {
            _currentTime = 0f;
        }

        private void Update()
        {
            _currentTime += Time.unscaledDeltaTime;
            UpdateUI();
        }

        public void UpdateUI()
        {
            _textHHMMSS.text = GetTime();
            _textMilliseconds.text = GetMilliseconds();
        }

        public string GetTime()
        {
            string sHours, sMinutes, sSeconds;

            sHours = Mathf.Floor(_currentTime / 3600).ToString("00");
            sMinutes = Mathf.Floor(_currentTime / 60).ToString("00");
            sSeconds = (_currentTime % 60).ToString("00");

            return sHours + ":" + sMinutes + ":" + sSeconds;
        }

        public string GetMilliseconds()
        {
            return ":" + ((_currentTime * 1000) % 1000).ToString("000");
        }
    }
}
