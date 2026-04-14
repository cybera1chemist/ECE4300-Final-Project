using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimescaleManager : MonoBehaviour
{
    public static TimescaleManager Instance { get; private set; }

    [Header("Bullet Time Settings")]
    [SerializeField] private float bulletTimeScale    = 0.25f;
    [SerializeField] private float transitionDuration = 0.12f;

    private float targetTimeScale = 1f;
    private int activePrepareCount = 0; // number of hands in Prepare state

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Duplicate TimescaleManager found. Disabling this instance.", this);
            enabled = false;
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        Time.timeScale = Mathf.Lerp(Time.timeScale, targetTimeScale, 
                                    Time.unscaledDeltaTime / transitionDuration);
    }

    #region public APIs
    public void RequestBulletTime()
    {
        activePrepareCount++;
        if (activePrepareCount == 1)
        {
            Debug.Log("Entering bullet time");
            targetTimeScale = bulletTimeScale;
        }
    }
    
    public void ReleaseBulletTime()
    {
        activePrepareCount--;
        if (activePrepareCount == 0)
        {
            Debug.Log("Exiting bullet time");
            targetTimeScale = 1.0f;
        }
    }
    #endregion
}
