using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI coinsText;

    public float coins {get; private set;} // In background coins is float, but when shown to player it's int

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
        coinsText.text = ((int)coins).ToString();
    }

    #region public API
    public void AddCoins(float amount)
    {
        coins += amount;
        UpdateUI();
    }

    public bool SpendCoins(float amount)
    {
        if (coins < amount) return false;
        coins -= amount;
        UpdateUI();
        return true;
    }
 
    #endregion
}
