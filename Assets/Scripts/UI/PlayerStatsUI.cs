using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerHPBar hpBar;
    [SerializeField] private TextMeshProUGUI coinsText;

    private void Start()
    {
        // Bind the UI elements to the PlayerStats singleton
        if (PlayerStats.Instance != null)
        {
            PlayerStats.Instance.BindHPBar(hpBar);
            PlayerStats.Instance.BindCoinsText(coinsText);
        }
    }
}
