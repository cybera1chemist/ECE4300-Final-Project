using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject gameOverPanel; // Game Over 面板
    public TextMeshProUGUI restartText;

    private void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // 初始化时隐藏游戏结束UI
        }

        if (restartText != null)
        {
            restartText.gameObject.SetActive(false); // 初始化时隐藏重启提示文本
        }
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // 显示 "Game Over"
        }

        if (restartText != null)
        {
            restartText.gameObject.SetActive(true); // 显示重启提示
        }
    }

    // 如果需要渐变效果
    public void FadeOutAndShowGameOver()
    {
        if (gameOverPanel != null)
        {
            CanvasGroup canvasGroup = gameOverPanel.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = gameOverPanel.AddComponent<CanvasGroup>();
            }
            gameOverPanel.GetComponent<UnityEngine.UI.Image>().color = Color.black;
            StartCoroutine(FadeOut(canvasGroup)); // 渐变显示
        }
    }

    private System.Collections.IEnumerator FadeOut(CanvasGroup canvasGroup)
    {
        float time = 0;
        float duration = 1f; // 渐变时间（可以调整）

        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, time / duration);
            yield return null;
        }

        // 游戏结束面板完全显示后调用
        ShowGameOver();
    }

    void Update()
    {
        // 检测按下 R 键时重启游戏
        if (Input.GetKeyDown(KeyCode.R)) // 按 R 键恢复游戏
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        Debug.Log($"[GameOverUIManager] RestartGame called. Current scene: {SceneManager.GetActiveScene().name}, timeScale: {Time.timeScale}");
        Debug.Log($"[GameOverUIManager] Before reset: PlayerHealth.isGameOver = {PlayerHealth.isGameOver}");

        PlayerHealth.isGameOver = false;
        Time.timeScale = 1f;

        Debug.Log($"[GameOverUIManager] After reset: PlayerHealth.isGameOver = {PlayerHealth.isGameOver}, timeScale: {Time.timeScale}");
        Debug.Log("[GameOverUIManager] Loading current scene again...");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
