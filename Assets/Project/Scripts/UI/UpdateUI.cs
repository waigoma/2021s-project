using Project;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private Text hpText;
    [SerializeField] private Text statusText;
    
    public PlayerStatus playerStatus;
    
    void Start()
    {
        hpText.text = $"{playerStatus.Hp} / {playerStatus.MaxHp}";
        statusText.text = $"MP: {playerStatus.Mp} / {playerStatus.MaxMp} Exp: {playerStatus.Experience} / {playerStatus.ReqExp}";
    }

    void Update()
    {
        hpText.text = $"{playerStatus.Hp} / {playerStatus.MaxHp}";
        statusText.text = $"MP: {playerStatus.Mp} / {playerStatus.MaxMp} Exp: {playerStatus.Experience} / {playerStatus.ReqExp}";
    }
}
