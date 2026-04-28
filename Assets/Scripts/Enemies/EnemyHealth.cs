using UnityEngine;
using UnityEngine.Events;
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

    public UnityEvent OnDeath;

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
        Vector3 spawnPos = uiRoot.transform.position + new Vector3(Random.Range(-0.1f, 0.1f), 0.25f, 0);
        GameObject dmgNumObj = Instantiate(damageNumberPrefab, spawnPos,
                                Quaternion.identity, null);
        dmgNumObj.GetComponent<DamageNumber>().Init(damage, magicBallColor);
    }

    private void Die()
    {
        SoundManager.Instance?.PlayEnemyDeathCoinSFX(); //activate the baojinbi coin sound effect (on soundmanager object)

        OnDeath?.Invoke();

        Destroy(gameObject);
    }
}
