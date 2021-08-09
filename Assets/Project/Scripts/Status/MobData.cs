using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public class MobData : MonoBehaviour
    {
        [SerializeField]private MobStatus mobStatus;
        [SerializeField]private Slider _slider;
        [SerializeField] private Canvas canvas;
        [SerializeField] private GameObject obj;

        private void Start()
        {
            _slider.maxValue = mobStatus.MaxHp;
        }

        void Update()
        {
            if (mobStatus.Hp != 0)
            {
                _slider.value = mobStatus.Hp;
                // GameObject.Find("MobSlider").transform.LookAt(GameObject.Find("Player"));
            }
            else
            {
                canvas.enabled = false;
                obj.SetActive(false);
                // Destroy(canvas, .5f);
            }
        }

        void OnDamage(int dmg)
        {
        }
    }
}
