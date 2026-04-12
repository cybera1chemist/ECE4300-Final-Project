using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float moveSpeed = 2f;

    private void FixedUpdate()
    {
        // move towards player
        // player is always at (0, 0, 0)
        Vector3 direction = (Vector3.zero - transform.position).normalized;
        transform.position += moveSpeed * Time.fixedDeltaTime * direction;

        // rotate to face player
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
        }
    }
}
