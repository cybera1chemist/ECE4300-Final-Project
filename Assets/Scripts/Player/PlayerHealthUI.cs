using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    [Header("UI References")]
    public Slider healthSlider;
    public TextMeshProUGUI healthText;

    private Image fillImage;

    private void Awake()
    {
        Debug.Log($"[PlayerHealthUI] Awake called. Object: {gameObject.name}, InstanceID: {GetInstanceID()}, Scene: {gameObject.scene.name}");

        if (healthSlider == null)
        {
            Debug.Log("[PlayerHealthUI] healthSlider is null in Awake. Trying GetComponentInChildren<Slider>(true)...");
            healthSlider = GetComponentInChildren<Slider>(true);
        }

        if (healthText == null)
        {
            Debug.Log("[PlayerHealthUI] healthText is null in Awake. Trying GetComponentInChildren<TextMeshProUGUI>(true)...");
            healthText = GetComponentInChildren<TextMeshProUGUI>(true);
        }

        if (healthSlider != null)
        {
            Debug.Log($"[PlayerHealthUI] healthSlider found: {healthSlider.name}, InstanceID: {healthSlider.GetInstanceID()}");

            if (healthSlider.fillRect != null)
            {
                fillImage = healthSlider.fillRect.GetComponent<Image>();

                if (fillImage != null)
                {
                    Debug.Log($"[PlayerHealthUI] fillImage found: {fillImage.name}, InstanceID: {fillImage.GetInstanceID()}");
                }
                else
                {
                    Debug.LogWarning("[PlayerHealthUI] fillRect exists, but Image component was not found.");
                }
            }
            else
            {
                Debug.LogWarning("[PlayerHealthUI] healthSlider.fillRect is null.");
            }
        }
        else
        {
            Debug.LogError($"[PlayerHealthUI] healthSlider is still null after search. Object: {gameObject.name}");
        }

        if (healthText != null)
        {
            Debug.Log($"[PlayerHealthUI] healthText found: {healthText.name}, InstanceID: {healthText.GetInstanceID()}");
        }
        else
        {
            Debug.LogError($"[PlayerHealthUI] healthText is still null after search. Object: {gameObject.name}");
        }
    }

    private void OnDestroy()
    {
        Debug.LogWarning($"[PlayerHealthUI] OnDestroy called. Object: {gameObject.name}, InstanceID: {GetInstanceID()}, Scene: {gameObject.scene.name}");
    }

    public void UpdateHealthUI(float currentHealth, float maxHealth)
    {
        Debug.Log($"[PlayerHealthUI] UpdateHealthUI called. Object: {gameObject.name}, InstanceID: {GetInstanceID()}, currentHealth: {currentHealth}, maxHealth: {maxHealth}");

        if (healthSlider == null)
        {
            Debug.LogError($"[PlayerHealthUI] UpdateHealthUI failed: healthSlider is null or destroyed. Object: {gameObject.name}, InstanceID: {GetInstanceID()}");
            return;
        }

        if (healthText == null)
        {
            Debug.LogError($"[PlayerHealthUI] UpdateHealthUI failed: healthText is null or destroyed. Object: {gameObject.name}, InstanceID: {GetInstanceID()}");
            return;
        }

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        healthText.text = "HP: " + Mathf.CeilToInt(currentHealth).ToString();

        float percent = maxHealth > 0f ? currentHealth / maxHealth : 0f;

        Debug.Log($"[PlayerHealthUI] UI updated successfully. Slider value: {healthSlider.value}/{healthSlider.maxValue}, percent: {percent}");

        if (fillImage == null && healthSlider.fillRect != null)
        {
            fillImage = healthSlider.fillRect.GetComponent<Image>();
        }

        if (fillImage != null)
        {
            fillImage.color = percent <= 0.3f ? Color.red : Color.green;
            Debug.Log($"[PlayerHealthUI] Health bar color updated. Current health: {currentHealth}, Percent: {percent}");
        }
        else
        {
            Debug.LogWarning("[PlayerHealthUI] fillImage is null. Health value updated, but color was not changed.");
        }
    }
}
