using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public class HpGauge : MonoBehaviour
    {
        [SerializeField] private Image greenGauge;
        [SerializeField] private Image redGauge;

        [SerializeField] private PlayerStatus playerStatus;
        private Tween redGaugeTween;

        public void SetGauge()
        {
            var fillAmount = (float)playerStatus.Hp / playerStatus.MaxHp;
            greenGauge.fillAmount = fillAmount;
            redGauge.fillAmount = fillAmount;
        }

        // HPを減らす前に呼ぶこと
        public void GaugeReduction(float reductionValue, float time = 1f)
        {
            var valueFrom = (float)playerStatus.Hp / playerStatus.MaxHp;
            var valueTo = (playerStatus.Hp - reductionValue) / playerStatus.MaxHp;

            greenGauge.fillAmount = valueTo;

            if (redGaugeTween != null) redGaugeTween.Kill();

            redGaugeTween = DOTween.To(
                () => valueFrom,
                x => { redGauge.fillAmount = x; },
                valueTo,
                time);
        }

        public void SetPlayer(PlayerStatus playerStatus)
        {
            this.playerStatus = playerStatus;
        }
    }
}
