using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project
{
    [Serializable]
    [CreateAssetMenu(fileName = "PlayerStatus", menuName = "CreatePlayerStatus")]
    public class PlayerStatus : BaseStatus
    {
        [SerializeField] private int earnedExp;
        [SerializeField] private int experience;
        [SerializeField] private int reqExp;
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

        public void AddExp(int exp)
        {
            Experience += exp;
            earnedExp += exp;
            LevelUp();
        }

        public void LevelUp()
        {
            // 経験値が必要経験値を超えなければ終了
            if (Experience <= reqExp) return;
            
            // レベル +1
            Level++;
            // 経験値レベルアップ計算
            Experience -= reqExp;
            // 必要経験値設定
            reqExp = Level * 10;
            // 経験値リセット
            Experience = 0;
        }
    }

}
