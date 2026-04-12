using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float maxHP = 10f;
    private float curHP;

    [Header("UI")]
    [SerializeField] private Image hpBarFill;

    private void Start()
    {
        curHP = maxHP;
        UpdateHPBar();
    }

    public void TakeDamage(float damage)
    {
        curHP -= damage;
        UpdateHPBar();

        if (curHP <= 0)
        {
            Die();
        }
    }

    private void UpdateHPBar()
    {
        if (hpBarFill != null)  hpBarFill.fillAmount = Mathf.Max(0, curHP / maxHP);
    }

        private void Die()
    {
        Destroy(gameObject);
    }
}
