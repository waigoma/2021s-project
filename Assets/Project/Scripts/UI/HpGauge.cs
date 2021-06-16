using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public class HpGauge : MonoBehaviour
    {
        [SerializeField] private Image greenGauge;
        [SerializeField] private Image redGauge;

        private PlayerStatus playerStatus;
        private Tween redGaugeTween;

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
