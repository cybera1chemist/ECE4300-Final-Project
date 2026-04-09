using TMPro;
using UnityEngine;

public class DebugTexts : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leftInfoText;
    [SerializeField] private TextMeshProUGUI rightInfoText;
    [SerializeField] private HandController leftHandController;
    [SerializeField] private HandController rightHandController;

    void Update()
    {
        SetText(HandSide.Left);
        SetText(HandSide.Right);
    }

    private void SetText(HandSide side)
    {
        string text = $"Hand: {side}\n";
        if (side == HandSide.Left)  
        {
            if (leftHandController.magicBall != null)
            {
                text += $"Delta: {leftHandController.magicBall.delta}\n";
                text += $"Color: {leftHandController.magicBall.GetColor()}\n";
            }
            else
                text += $"Color: N/A\n";
            leftInfoText.text = text;
        }
        else  
        {
            if (rightHandController.magicBall != null)
            {
                text += $"Delta: {rightHandController.magicBall.delta}\n";
                text += $"Color: {rightHandController.magicBall.GetColor()}\n";
            }
            else
                text += $"Color: N/A\n";
            rightInfoText.text = text;
        }
    }
}
