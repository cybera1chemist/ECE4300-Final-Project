using TMPro;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    [Header("Base Stats")]
    [SerializeField] private float baseDamage;
    [SerializeField] private float defense;
    [SerializeField] private float maxHP;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private PlayerHPBar hpBar;

    public float BaseDamage {get; private set;}
    public float Defense {get; private set;}
    public float MaxHP {get; private set;}

    public float Coins {get; private set;} // In background coins is float, but when shown to player it's int

    private PlayerHealth health;

    private void Awake()
    {
        if (Instance != null && Instance != this)  Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        BaseDamage = baseDamage;
        Defense = defense;
        MaxHP = maxHP;

        health = GetComponent<PlayerHealth>();
        health.SetMaxHP(MaxHP);
    }

    private void Start()
    {
        UpdateUI();
    }
    
    public void UpdateUI()
    {
        // update coins
        if (coinsText != null) coinsText.text = ((int)Coins).ToString();

        // update healthBar
        if (hpBar != null) hpBar.UpdateUI(health.GetCurHP(), MaxHP);

    }

    #region public API
    public void AddCoins(float amount)
    {
        Coins += amount;
        UpdateUI();
    }

    public bool SpendCoins(float amount)
    {
        if (Coins < amount) return false;
        Coins -= amount;
        UpdateUI();
        return true;
    }

    public void AddDamage(float amount) => BaseDamage += amount;
    public void AddDefense(float amount) => Defense += amount;
    public void AddMaxHP(float amount) {
        MaxHP += amount;
        health.SetMaxHP(MaxHP);
        UpdateUI();
    }
 
    #endregion

    #region Bind UI
    public void BindCoinsText(TextMeshProUGUI text)
    {
        coinsText = text;
        UpdateUI();
    }
    #endregion
}
