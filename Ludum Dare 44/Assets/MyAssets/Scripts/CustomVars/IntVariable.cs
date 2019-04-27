using System;
using UnityEngine;

namespace AdrianKovatana
{
    [CreateAssetMenu(menuName = "Data/Variables/Int")]
    public class IntVariable : ScriptableObject
    {
        public int initialValue;
        public int value;

        public void ResetValue()
        {
            value = initialValue;
        }
    }
}
