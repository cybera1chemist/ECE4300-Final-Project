using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float moveSpeed = 2f;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        // move towards player
        // player is always at (0, 0, 0)
        Vector3 direction = (Vector3.zero - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.fixedDeltaTime;
    }
}
