using System;
using UnityEngine;

namespace AdrianKovatana
{
    [CreateAssetMenu(menuName = "Data/Game/Event")]
    public class GameEvent : ScriptableObject
    {
        private Action _listener;

        public void Invoke()
        {
            _listener?.Invoke();
        }

        public void RegisterListener(Action action)
        {
            _listener += action;
        }

        public void UnregisterListener(Action action)
        {
            _listener -= action;
        }
    }
}
