using UnityEngine;

public class TitleScene : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        Debug.Log("[TitleScene] Start button pressed. Loading Area 1 Stage 1...");
        AreaManager.Instance.StartArea();
    }
}
