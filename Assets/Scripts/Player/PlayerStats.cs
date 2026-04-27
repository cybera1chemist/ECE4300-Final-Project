using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI coinsText;

    public float BaseDamage {get; private set;}
    public float Defense {get; private set;}
    public float MaxHP {get; private set;}

    public float Coins {get; private set;} // In background coins is float, but when shown to player it's int

    private void Awake()
    {
        if (Instance != null && Instance != this)  Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        coinsText.text = ((int)Coins).ToString();
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
    public void AddMaxHP(float amount) => MaxHP += amount;
 
    #endregion
}
