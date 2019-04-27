using UnityEngine;

namespace AdrianKovatana
{
    [CreateAssetMenu(menuName = "Data/Variables/Float")]
    public class FloatVariable : ScriptableObject
    {
        public float initialValue;
        public float value;

        public void ResetValue()
        {
            value = initialValue;
        }
    }
}
