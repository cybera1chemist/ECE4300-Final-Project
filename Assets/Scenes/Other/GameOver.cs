using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void OnRetryButtonPressed()
    {
        AreaManager.Instance.ReturnToTitle();
    }
}
