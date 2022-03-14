using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sections
{
    public class Section : MonoBehaviour, IPointerClickHandler
    {
        private const string ItemHolderPrefabPath = "Items/ItemHolder";

        [SerializeField] private Item[] _items;
        [SerializeField] private int _maxCount = 5;

        private ItemHolder _itemHolderPrefab;
        private Queue<ItemHolder> _holders;

        private void Start()
        {
            _itemHolderPrefab =
                Resources.Load<ItemHolder>(ItemHolderPrefabPath);
            _holders = new Queue<ItemHolder>(_maxCount);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            DestroyWithFull();
            
            ItemHolder itemHolder = Instantiate(_itemHolderPrefab, eventData.position, Quaternion.identity, transform);
            _holders.Enqueue(itemHolder);

            Item randomItem = GetRandomSuitableItem();

            itemHolder.SetItem(randomItem);
        }

        private void DestroyWithFull()
        {
            if (_holders.Count == _maxCount)
            {
                Destroy(_holders.Dequeue().gameObject);
            }
        }

        private Item GetRandomSuitableItem()
        {
            Item randomItem = null;
            do
            {
                randomItem = _items.GetRandom();

                if (_holders.Count(matchItemHolder => matchItemHolder.IsItemHolding(randomItem)) == randomItem.maxCount)
                {
                    randomItem = null;
                }
                
            } while (randomItem == null);

            return randomItem;
        }
    }
}
