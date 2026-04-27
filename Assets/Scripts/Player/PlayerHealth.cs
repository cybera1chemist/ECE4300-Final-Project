using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float maxHP;
    private float curHP;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = PlayerStats.Instance.MaxHP;
    }


    #region public API
    public float GetMaxHP() => maxHP;
    public void SetMaxHP(float hp) => maxHP = hp;
    public float GetCurHP() => curHP;
    #endregion
}
