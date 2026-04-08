using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;

    [Header("Skill 1: Fireball")]
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private float fireballSpeed;
    [SerializeField] private float fireballDamage;
    
    public void GenerateFireball()
    {
        if (fireballPrefab == null)
        {
            Debug.LogWarning("Fireball prefab is not assigned.");
            return;
        }

        // Instantiate fireball at the right hand's position and rotation
        Instantiate(fireballPrefab, rightHand.transform.position, rightHand.transform.rotation);
    }

    public void ReleaseFireball()
    {
        
    }
}
