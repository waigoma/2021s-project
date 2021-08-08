using UnityEngine;

namespace Project
{
    public class MobData : MonoBehaviour
    {
        [SerializeField]private MobStatus mobStatus;

        private HpGauge hpGauge;

        private void Start()
        {
            hpGauge = GameObject.Find("UpdateUI").GetComponent<HpGauge>();
        }

        void Update()
        {
        }

        void OnDamage(int dmg)
        {
        }
    }
}
