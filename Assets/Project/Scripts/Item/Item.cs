using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    [Serializable]
    [CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
    public class Item : ScriptableObject
    {
        public enum Type
        {
            HpRecovery,
            MpRecovery,
            PoisonRecovery,
            NumbnessRecovery,
            Weapon,
            Armor,
            Valuables
        }
        
        public enum Tier
        {
            Normal,
            Rare,
            Epic,
            Legendary
        }

        [SerializeField] private Type itemType; 
        [SerializeField] private string kanjiName;
        [SerializeField] private string hiraganaName;
        [SerializeField] private Tier itemTier;
        [SerializeField] private string information;
        [SerializeField] private int amount;

        public Type ItemType
        {
            get => itemType; 
            private set => itemType = value;
        }

        public string KanjiName
        {
            get => kanjiName;
            set => kanjiName = value;
        }

        public string HiraganaName
        {
            get => hiraganaName;
            set => hiraganaName = value;
        }

        public Tier ItemTier
        {
            get => itemTier;
            set => itemTier = value;
        }

        public string Information
        {
            get => information;
            set => information = value;
        }

        public int Amount
        {
            get => amount;
            set => amount = value;
        }
    }
}

