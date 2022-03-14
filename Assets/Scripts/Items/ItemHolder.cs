using System;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class ItemHolder : MonoBehaviour
    {
        private Image _image;

        private Item _item;

        public void SetItem(Item item)
        {
            _image = GetComponent<Image>();
            _item = item;
            _image.sprite = item.sprites.GetRandom();
            transform.localScale *= item.sizeModifier;
        }

        public bool IsItemHolding(Item item)
        {
            return _item == item;
        }
    }
}