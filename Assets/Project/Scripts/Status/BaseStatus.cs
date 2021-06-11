using System;
using UnityEngine;

namespace Project
{
    [Serializable]
    public abstract class BaseStatus : ScriptableObject
    {
        [SerializeField] private string characterName;
        [SerializeField] private int hp;
        [SerializeField] private int maxHp;
        [SerializeField] private int mp;
        [SerializeField] private int maxMp;
        [SerializeField] private int level;
        [SerializeField] private int agility;
        [SerializeField] private int strength;
        [SerializeField] private int intelligence;

        public string CharacterName
        {
            get => characterName; 
            set => characterName = value;
        }
        
        public int Hp
        {
            get => hp;
            set => hp = Mathf.Max(0, Mathf.Min(MaxHp, value));
        }
        public int MaxHp
        {
            get => maxHp; 
            set => maxHp = value;
        }
        
        
        public int Mp
        {
            get => mp;
            set => mp = Mathf.Max(0, Mathf.Min(MaxMp, value));
        }
        public int MaxMp
        {
            get => maxMp; 
            set => maxMp = value;
        }

        public int Level
        {
            get => level; 
            set => level = value;
        }


        public int Agility
        {
            get => agility; 
            set => agility = value;
        }

        public int Strength
        {
            get => strength; 
            set => strength = value;
        }

        public int Intelligence
        {
            get => intelligence; 
            set => intelligence = value;
        }
    }
}
