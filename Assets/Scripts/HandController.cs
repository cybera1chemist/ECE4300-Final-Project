using System.Collections;
using System.Collections.Generic;
using Leap;
using UnityEngine;

public enum HandState {
    Idle,
    Prepare,
    Fire
}

public class HandController : MonoBehaviour
{
    [Header("Config")]
    public HandSide side;
    [SerializeField] private float fireSpeedThreshold = 1.2f; // m/s

    [Header("References")]
    [SerializeField] private MagicBall magicBall;

    public HandState curState { get; private set; }
    public Color curColor { get; private set; }

    private bool hasLoggedMissingBridge;

    private void Start()
    {
        curState = HandState.Idle;
    }

    private void Update()
    {
        if (curState != HandState.Prepare) return;

        var bridge = LeapInputBridge.Instance;
        if (bridge == null)
        {
            if (!hasLoggedMissingBridge)
            {
                Debug.LogError("LeapInputBridge.Instance is null. Ensure a LeapInputBridge object is active in the scene.", this);
                hasLoggedMissingBridge = true;
            }
            return;
        }

        magicBall.UpdatePosition(bridge.GetHandPosition(side), bridge.GetPalmNormal(side));
    }
    
    #region Called by PoseDetector in Unity Editor
    public void OnPalmDetected()
    {
        SetState(HandState.Prepare);
    }
    public void OnPalmLost()
    {
        if (curState == HandState.Prepare)
        {
            SetState(HandState.Idle);
        }
    }
    public void OnFistDetected()
    {
        if (curState != HandState.Prepare) return;
        SetState(HandState.Fire);

    }
    public void OnFistLost()
    {
        if (curState == HandState.Fire)
        {
            SetState(HandState.Idle);
        }
    }
    #endregion

    private void SetState(HandState newState)
    {
        curState = newState;
        switch (curState)
        {
            case HandState.Idle:
                Debug.Log("Player's " + side + " hand switched to idle state.");
                magicBall.SetVisible(false);
                break;
            case HandState.Prepare:
                Debug.Log("Player's " + side + " hand switched to prepare state.");
                magicBall.SetVisible(true);
                break;
            case HandState.Fire:
                Debug.Log("Player's " + side + " hand switched to fire state.");
                magicBall.SetVisible(false);
                break;
        }
    }
}
