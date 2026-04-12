using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float maxHP = 10f;
    private float curHP;

    private void Start()
    {
        curHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        curHP -= damage;
        if (curHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
