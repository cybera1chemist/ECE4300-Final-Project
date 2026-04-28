using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public static AreaManager Instance { get; private set; }

    [SerializeField] private AreaConfig areaConfig;

    [Header("Scene Transition")]
    [SerializeField] private string stageSceneName;
    [SerializeField] private string shopSceneName = "Scenes/Shop/Shop";

    public int CurStageIndex { get; private set; }

    private void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageComplete()
    {
        
        // switch to shop scene
        Debug.Log($"Stage {CurStageIndex} complete! Loading shop scene...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(shopSceneName);
        CurStageIndex++;
    }

    public void ExitShop()
    {
        // switch to stage scene
        Debug.Log($"Exiting shop, loading stage scene for stage {CurStageIndex}...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(stageSceneName);
    }

    #region public API for get
    public StageConfig GetCurStageConfig() => areaConfig.stageConfigs[CurStageIndex];
    public StageConfig GetStageConfigAt(int stageIndex) => areaConfig.stageConfigs[stageIndex];
    #endregion
}
