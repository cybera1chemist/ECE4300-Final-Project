using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
<<<<<<< HEAD
    [Header("Health Settings")]
    public float maxHealth = 100f;

    private float currentHealth;
    private bool hasInitialized = false;

    public static bool isGameOver = false;

    [Header("UI References")]
    public PlayerHealthUI healthUI;
    public GameOverUIManager gameOverUI;

    private void Awake()
    {
        Debug.Log($"[PlayerHealth] Awake called. Object: {gameObject.name}, InstanceID: {GetInstanceID()}, Scene: {gameObject.scene.name}");

        InitializeHealth();
    }

    private IEnumerator Start()
    {
        Debug.Log($"[PlayerHealth] Start coroutine called. currentHealth = {currentHealth}, maxHealth = {maxHealth}");

        yield return null;

        BindReferences();

        ResetHealthToMax();
        UpdateHealthUI();

        Debug.Log($"[PlayerHealth] Start coroutine finished. currentHealth = {currentHealth}, maxHealth = {maxHealth}");
    }

    private void InitializeHealth()
    {
        isGameOver = false;
        currentHealth = maxHealth;
        hasInitialized = true;

        Debug.Log($"[PlayerHealth] InitializeHealth called. currentHealth set to {currentHealth}/{maxHealth}");
    }

    private void ResetHealthToMax()
    {
        currentHealth = maxHealth;
        isGameOver = false;
        hasInitialized = true;

        Debug.Log($"[PlayerHealth] ResetHealthToMax called. currentHealth reset to {currentHealth}/{maxHealth}");
    }

    private void BindReferences()
    {
        if (healthUI == null)
        {
            Debug.Log("[PlayerHealth] healthUI is null. Trying FindObjectOfType<PlayerHealthUI>(true)...");
            healthUI = FindObjectOfType<PlayerHealthUI>(true);
        }

        if (healthUI != null)
        {
            Debug.Log($"[PlayerHealth] healthUI found. UI Object: {healthUI.gameObject.name}, InstanceID: {healthUI.GetInstanceID()}, ActiveInHierarchy: {healthUI.gameObject.activeInHierarchy}");
        }
        else
        {
            Debug.LogError("[PlayerHealth] healthUI is still null after FindObjectOfType<PlayerHealthUI>(true).");
        }

        if (gameOverUI == null)
        {
            Debug.Log("[PlayerHealth] gameOverUI is null. Trying FindObjectOfType<GameOverUIManager>(true)...");
            gameOverUI = FindObjectOfType<GameOverUIManager>(true);
        }

        if (gameOverUI != null)
        {
            Debug.Log($"[PlayerHealth] gameOverUI found. Object: {gameOverUI.gameObject.name}, InstanceID: {gameOverUI.GetInstanceID()}, ActiveInHierarchy: {gameOverUI.gameObject.activeInHierarchy}");
        }
        else
        {
            Debug.LogWarning("[PlayerHealth] gameOverUI is still null.");
        }
    }

    public void TakeDamage(float damage)
    {
        Debug.Log(
            $"[PlayerHealth] TakeDamage ENTER. " +
            $"damage: {damage}, " +
            $"currentHealth BEFORE oldHealth: {currentHealth}, " +
            $"maxHealth: {maxHealth}, " +
            $"hasInitialized: {hasInitialized}, " +
            $"isGameOver: {isGameOver}, " +
            $"Object: {gameObject.name}, " +
            $"InstanceID: {GetInstanceID()}, " +
            $"Scene: {gameObject.scene.name}"
        );

        if (!hasInitialized)
        {
            Debug.LogError("[PlayerHealth] TakeDamage called before initialization. Reinitializing health now.");
            InitializeHealth();
        }

        if (currentHealth <= 0f && !isGameOver)
        {
            Debug.LogWarning(
                "[PlayerHealth] currentHealth is already 0 before taking damage while game is not over. " +
                "This means health was not reset correctly or this is an old PlayerHealth reference. " +
                "Forcing currentHealth back to maxHealth."
            );

            currentHealth = maxHealth;
            UpdateHealthUI();
        }

        if (isGameOver)
        {
            Debug.Log("[PlayerHealth] TakeDamage ignored because game is already over.");
            return;
        }

        float oldHealth = currentHealth;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0f);

        Debug.Log($"[PlayerHealth] Health changed: {oldHealth} -> {currentHealth}");

        UpdateHealthUI();

        if (currentHealth <= 0f)
        {
            Debug.Log("[PlayerHealth] Current health <= 0. Calling Die().");
            Die();
        }
    }


    private void UpdateHealthUI()
    {
        Debug.Log($"[PlayerHealth] UpdateHealthUI wrapper called. currentHealth: {currentHealth}, maxHealth: {maxHealth}, hasInitialized: {hasInitialized}, isGameOver: {isGameOver}, healthUI == null: {healthUI == null}");

        if (healthUI == null)
        {
            Debug.LogWarning("[PlayerHealth] healthUI is null before UI update. Trying FindObjectOfType<PlayerHealthUI>(true)...");
            healthUI = FindObjectOfType<PlayerHealthUI>(true);
        }

        if (healthUI != null)
        {
            Debug.Log($"[PlayerHealth] Calling healthUI.UpdateHealthUI. UI Object: {healthUI.gameObject.name}, InstanceID: {healthUI.GetInstanceID()}");
            healthUI.UpdateHealthUI(currentHealth, maxHealth);
        }
        else
        {
            Debug.LogError("[PlayerHealth] Cannot update health UI because PlayerHealthUI was not found in scene.");
        }
    }

    private void Die()
    {
        Debug.Log($"[PlayerHealth] Die called. isGameOver: {isGameOver}, currentHealth: {currentHealth}");

        if (isGameOver)
        {
            Debug.Log("[PlayerHealth] Die ignored because game is already over.");
            return;
        }

        isGameOver = true;

        Debug.Log("[PlayerHealth] Player has died. isGameOver set to true.");

        if (gameOverUI == null)
        {
            BindReferences();
        }

        if (gameOverUI != null)
        {
            Debug.Log($"[PlayerHealth] Calling gameOverUI.FadeOutAndShowGameOver. Object: {gameOverUI.gameObject.name}, InstanceID: {gameOverUI.GetInstanceID()}");
            gameOverUI.FadeOutAndShowGameOver();
        }
        else
        {
            Debug.LogError("[PlayerHealth] gameOverUI not found. Cannot show game over UI.");
        }

        Time.timeScale = 0f;

        Debug.Log("[PlayerHealth] Time.timeScale set to 0.");
    }
=======
    private float maxHP;
    private float curHP;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = PlayerStats.Instance.MaxHP;
    }


    #region public API
    public float GetMaxHP() => maxHP;
    public void SetMaxHP(float hp) => maxHP = hp;
    public float GetCurHP() => curHP;
    #endregion
>>>>>>> dev
}
