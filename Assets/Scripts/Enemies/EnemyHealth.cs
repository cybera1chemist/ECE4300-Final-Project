using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float maxHP = 10f;
    private float curHP;

    [Header("UI")]
    [SerializeField] private GameObject uiRoot;
    [SerializeField] private Image hpBarFill;
    [SerializeField] private GameObject damageNumberPrefab;

    private void Start()
    {
        curHP = maxHP;
        UpdateHPBar();
    }

    public void TakeDamage(float damage, Color magicBallColor)
    {
        curHP -= damage;

        // UI
        UpdateHPBar();
        SpawnDamageNumber(damage, magicBallColor);

        if (curHP <= 0)
        {
            Die();
        }
    }

    private void UpdateHPBar()
    {
        if (hpBarFill != null)  hpBarFill.fillAmount = Mathf.Max(0, curHP / maxHP);
    }

    private void SpawnDamageNumber(float damage, Color magicBallColor)
    {
        Vector3 spawnPos = uiRoot.transform.position + new Vector3(Random.Range(-0.3f, 0.3f), 0, 0);
        GameObject dmgNumObj = Instantiate(damageNumberPrefab.gameObject, spawnPos,
                                Quaternion.identity, uiRoot.transform);
        dmgNumObj.GetComponent<DamageNumber>().Init(damage, magicBallColor);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
