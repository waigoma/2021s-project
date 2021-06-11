using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    [Serializable]
    [CreateAssetMenu(fileName = "PlayerStatus", menuName = "CreatePlayerStatus")]
    public class PlayerStatus : BaseStatus
    {
        [SerializeField] private int experience;
        [SerializeField] private int reqExp;
        [SerializeField] private int stamina;

        public int Stamina
        {
            get => stamina; 
            set => stamina = value;
        }

        public void AddExp(int exp)
        {
            experience += exp;
            LevelUp();
        }

        public void LevelUp()
        {
            // 経験値が必要経験値を超えなければ終了
            if (experience <= reqExp) return;
            
            // レベル +1
            Level++;
            // 経験値レベルアップ計算
            experience -= reqExp;
            // 必要経験値設定
            reqExp = Level * 10;
        }
    }

}
