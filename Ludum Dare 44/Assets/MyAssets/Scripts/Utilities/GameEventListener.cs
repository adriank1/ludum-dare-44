using UnityEngine;
using UnityEngine.Events;

namespace AdrianKovatana
{
    /* Can be difficult to manage in the scene
     * Consider using this for quickly testing functionality only
     */
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent gameEvent;
        public UnityEvent response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(Respond);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(Respond);
        }

        private void Respond()
        {
            response.Invoke();
        }
    }
}
