using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float distanceFromPalm = 0.2f;

    void Start()
    {
        SetVisible(false);
    }

    #region Public APIs
    public void SetVisible(bool visible)
    {
        gameObject.SetActive(visible);
    }

    public void SetColor(Color color)
    {

    }

    public void UpdatePosition(Vector3 palmPosition, Vector3 palmNormal)
    {
        transform.position = palmPosition + palmNormal.normalized * distanceFromPalm;
    }

    #endregion
}
