// Used for magic ball only

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MagicBall))]
public class Projectile : MonoBehaviour
{
    private float damage = 10f;
    private MagicBall magicBall;

     private void Start()
    {
        magicBall = GetComponent<MagicBall>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.TryGetComponent<EnemyHealth>(out var enemyHealth))
            {
                if (other.TryGetComponent<EnemyController>(out var enemyController))
                {
                    // Change damage based on color difference
                    Color enemyColor = enemyController.GetColor();
                    float colorDiff = ColorMath.HueDistance(enemyColor, magicBall.GetColor());
                    float damageMultiplier = 1f + colorDiff;

                    damage *= damageMultiplier;
                }
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    #region public API
    public void SetDamage(float dmg) => damage = dmg;
    public float GetDamage() => damage;

    #endregion
}
