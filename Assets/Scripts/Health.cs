using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isDead;

    public int CurrentHealth
    {
        get => currentHealth;
        private set
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
            CheckHealth();
        }
    }

    private void Start()
    {
        CurrentHealth = maxHealth;
    }

    private void CheckHealth()
    {
        if (!isDead && CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0 || isDead)
        {
            return;
        }

        CurrentHealth -= amount;
    }

    public void Heal(int amount)
    {
        if (amount <= 0 || isDead)
        {
            return;
        }

        CurrentHealth += amount;
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Player has died.");
        // Add death logic here (e.g., respawn, game over screen, etc.)
    }
}
