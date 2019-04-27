using UnityEditor;
using UnityEngine;

namespace AdrianKovatana
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GameEvent gameEvent = (GameEvent)target;
            if(GUILayout.Button("Invoke"))
            {
                gameEvent.Invoke();
            }
        }
    }
}
