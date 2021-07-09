using Project;
using TMPro;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI statusText;
    private HpGauge hpGauge;
    
    public PlayerStatus playerStatus;
    
    void Start()
    {
        hpText.text = $"{playerStatus.Hp} / {playerStatus.MaxHp}";
        statusText.text = $"MP: {playerStatus.Mp} / {playerStatus.MaxMp} Exp: {playerStatus.Experience} / {playerStatus.ReqExp}";
        hpGauge = GameObject.Find("UpdateUI").GetComponent<HpGauge>();
        hpGauge.SetGauge();
    }

    void Update()
    {
        hpText.text = $"{playerStatus.Hp} / {playerStatus.MaxHp}";
        statusText.text = $"MP: {playerStatus.Mp} / {playerStatus.MaxMp} Exp: {playerStatus.Experience} / {playerStatus.ReqExp}";
    }
}
