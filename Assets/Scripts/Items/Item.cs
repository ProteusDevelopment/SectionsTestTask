using UnityEngine;

namespace Items
{
    [System.Serializable]
    public class Item
    {
        public Sprite[] sprites;
        public int maxCount = 1;
        public float sizeModifier = 1f;
    }
}