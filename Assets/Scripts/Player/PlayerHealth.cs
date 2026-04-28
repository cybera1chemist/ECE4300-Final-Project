using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    private float maxHP; // Set by PlayerStats.cs
    private float curHP;

    public static bool isGameOver = false;

    private void Awake()
    {
        isGameOver = false;
        curHP = maxHP;
    }

    private void Start()
    {
        curHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        if (isGameOver)  return;

        curHP -= damage;
        curHP = Mathf.Max(curHP, 0f);
        PlayerStats.Instance.UpdateUI();

        if (curHP <= 0f)  Die();
    }

    private void Die()
    {
        if (isGameOver)  return;

        isGameOver = true;

        AreaManager.Instance.GameOver();
    }

    #region public API
    public float GetMaxHP() => maxHP;
    public void SetMaxHP(float hp) => maxHP = hp;
    public float GetCurHP() => curHP;
    #endregion
}
