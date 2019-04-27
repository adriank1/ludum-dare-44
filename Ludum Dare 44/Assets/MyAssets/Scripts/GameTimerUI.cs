using TMPro;
using UnityEngine;

namespace AdrianKovatana
{
    public class GameTimerUI : MonoBehaviour
    {
#pragma warning disable
        [SerializeField]
        private FloatVariable _currentTime;

        [Header("UI Text")]
        [SerializeField]
        private TextMeshProUGUI _textHours;
        [SerializeField]
        private TextMeshProUGUI _textMinutes;
        [SerializeField]
        private TextMeshProUGUI _textSeconds;
        [SerializeField]
        private TextMeshProUGUI _textMilliseconds;
#pragma warning restore
        
        private void Update()
        {
            UpdateUI();
        }

        public void UpdateUI()
        {
            _textHours.text = GetHours();
            _textMinutes.text = ":" + GetMinutes();
            _textSeconds.text = ":" + GetSeconds();
            _textMilliseconds.text = ":" + GetMilliseconds();
        }

        public string GetHours()
        {
            return ((int)(_currentTime.value / 3600f) % 24).ToString("D2");
        }

        public string GetMinutes()
        {
            return ((int)(_currentTime.value / 60f) % 60).ToString("D2");
        }

        public string GetSeconds()
        {
            return ((int)(_currentTime.value % 60f)).ToString("D2");
        }

        public string GetMilliseconds()
        {
            return ((int)(_currentTime.value * 1000f) % 1000).ToString("D3");
        }
    }
}
