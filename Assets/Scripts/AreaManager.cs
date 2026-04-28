using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public static AreaManager Instance { get; private set; }

    [SerializeField] private AreaConfig areaConfig;

    [Header("Scene Transition")]
    [SerializeField] private string stageSceneName;
    [SerializeField] private string shopSceneName = "Scenes/Shop/Shop";
    [SerializeField] private string titleSceneName = "Scenes/Other/Title";
    [SerializeField] private string gameOverSceneName = "Scenes/Other/GameOver";
    [SerializeField] private string winSceneName = "Scenes/Other/Win";

    public int CurStageIndex { get; private set; }

    private void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Debug.Log("Area Manager is ready!");
    }

    public void StartArea()
    {
        CurStageIndex = 0;
        Debug.Log($"[AreaManager] Starting area with stage {CurStageIndex+1}. Loading stage scene...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(stageSceneName);
    }

    public void StageComplete()
    {
        if (CurStageIndex >= areaConfig.stageConfigs.Count)
        {
            Debug.LogError($"[AreaManager] All stages in the area are already completed! CurStageIndex: {CurStageIndex}");
            UnityEngine.SceneManagement.SceneManager.LoadScene(winSceneName);
            return;
        }
        
        // switch to shop scene
        Debug.Log($"[AreaManager] Stage {CurStageIndex+1} complete! Loading shop scene...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(shopSceneName);
        CurStageIndex++;
    }

    public void ExitShop()
    {
        // switch to stage scene
        Debug.Log($"[AreaManager] Exiting shop, loading stage scene for stage {CurStageIndex+1}...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(stageSceneName);
    }

    public void GameOver()
    {
        Debug.Log($"[AreaManager] Game over! Loading the game over scene...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameOverSceneName);
    }

    public void ReturnToTitle()
    {
        Debug.Log($"[AreaManager] Returning to title scene...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(titleSceneName);
    }

    #region public API for get
    public StageConfig GetCurStageConfig() => areaConfig.stageConfigs[CurStageIndex];
    public StageConfig GetStageConfigAt(int stageIndex) => areaConfig.stageConfigs[stageIndex];
    #endregion
}
