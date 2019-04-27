using UnityEngine;

namespace AdrianKovatana
{
    [CreateAssetMenu(menuName = "Data/Variables/Bool")]
    public class BoolVariable : ScriptableObject
    {
        public bool initialValue;
        public bool value;

        public void ResetValue()
        {
            value = initialValue;
        }
    }
}
