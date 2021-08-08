using UnityEngine;

namespace Project
{
    public class PlayerData : MonoBehaviour
    {
        [SerializeField]private PlayerStatus playerStatus;

        private HpGauge hpGauge;

        private void Start()
        {
            hpGauge = GameObject.Find("UpdateUI").GetComponent<HpGauge>();
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // OnDamage(10);
                Debug.Log($"{playerStatus.CharacterName} : {playerStatus.Hp}");
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                Debug.Log($"{playerStatus.CharacterName} : {playerStatus.Hp}");
            }
        }

        void OnDamage(int dmg)
        {
            hpGauge.GaugeReduction(dmg);
            playerStatus.Hp -= dmg;
        }
    }
}
