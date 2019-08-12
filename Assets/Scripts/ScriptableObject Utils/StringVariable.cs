using UnityEngine;

namespace SO_Utilities
{
    [CreateAssetMenu(menuName = "Variable/String")]
    public class StringVariable : ScriptableObject
    {
        [SerializeField]
        private string value = "";

        public string Value
        {
            get => value;
            set => this.value = value;
        }
    }
}