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
    [SerializeField] private MagicBall magicBallPrefab;

    public HandState curState { get; private set; }

    public MagicBall magicBall;
    private bool hasBallInHand = false;
    private LeapInputBridge bridge;

    private void Start()
    {
        bridge = LeapInputBridge.Instance;
        curState = HandState.Idle;
    }

    private void Update()
    {
        if (curState != HandState.Prepare) return;

        if (magicBall != null)
        {
            magicBall.UpdatePosition(bridge.GetHandPosition(side), bridge.GetPalmNormal(side));
        }
        
    }
    
    #region Called by PoseDetector in Unity Editor
    public void OnPalmDetected()
    {
        SetState(HandState.Prepare);        
    }
    public void OnPalmLost()
    {
        
    }

    public void OnFistDetected()
    {
        if (curState != HandState.Prepare) return;
        // Add special particles later
    }
    public void WhileFistDetected()
    {
        Vector3 velocity = LeapInputBridge.Instance.GetVelocity(side);
        if (velocity.magnitude >= fireSpeedThreshold && velocity.z > 0)        
        {
            SetState(HandState.Fire);
        }
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

                hasBallInHand = false;

                if (magicBall != null)
                {
                    magicBall.Cancel();
                }
                break;

            case HandState.Prepare:
                Debug.Log("Player's " + side + " hand switched to prepare state.");
                // Instantiate a new magic ball;
                if (!hasBallInHand)
                {
                    magicBall = Instantiate(magicBallPrefab, transform.position, Quaternion.identity);
                    magicBall.SetSide(side);
                    hasBallInHand = true;
                }
                break;

            case HandState.Fire:
                Debug.Log("Player's " + side + " hand switched to fire state.");
                Vector3 v = LeapInputBridge.Instance.GetVelocity(side);
                magicBall.Launch(v);
                break;
        }
    }
}
