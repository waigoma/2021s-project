using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project
{
    [Serializable]
    [CreateAssetMenu(fileName = "MobStatus", menuName = "Status/CreateMobStatus")]
    public class MobStatus : BaseStatus
    {
        [SerializeField] private int experience;
        [SerializeField] private int stamina;
        [SerializeField] private Item equipWeapon;
        [SerializeField] private Item equipArmor;

        [SerializeField] private ItemDictionary itemDictionary;
        

        public int Experience
        {
            get => experience;
            set => experience = value;
        }

        public int Stamina
        {
            get => stamina; 
            set => stamina = value;
        }

        public ItemDictionary GetItemDictionary()
        {
            return itemDictionary;
        }

        public IOrderedEnumerable<KeyValuePair<Item, int>> GetSortItemDictionary()
        {
            return itemDictionary.OrderBy(item => item.Key.HiraganaName);
        }
        
        public int SetItemNum(Item tmpItem, int num)
        {
            return itemDictionary[tmpItem] = num;
        }

        public int GetItemNum(Item item)
        {
            return itemDictionary[item];
        }

    }

}
