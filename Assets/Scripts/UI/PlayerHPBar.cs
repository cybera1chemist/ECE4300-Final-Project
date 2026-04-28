using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image hpBarFill;
    [SerializeField] private TextMeshProUGUI text;

    public void UpdateUI(float curHP, float maxHP)
    {
        if (hpBarFill != null)  hpBarFill.fillAmount = Mathf.Max(0, curHP / maxHP);
        text.text = $"{ (int)curHP} / {(int)maxHP}";
    }
}
