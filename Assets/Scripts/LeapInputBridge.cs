using UnityEngine;
using Leap;

public enum HandSide { Left, Right }

public class LeapInputBridge : MonoBehaviour
{
    [SerializeField] private LeapServiceProvider leapProvider;

    public static LeapInputBridge Instance { get; private set; }

    private Vector3 handPositionL;
    private Vector3 handPositionR;
    private Vector3 palmNormalL;
    private Vector3 palmNormalR;
    private Vector3 handVelocityL;
    private Vector3 handVelocityR;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Duplicate LeapInputBridge found. Disabling this instance.", this);
            enabled = false;
            return;
        }

        Instance = this;

        if (leapProvider == null)
        {
            leapProvider = FindFirstObjectByType<LeapServiceProvider>();
        }

        if (leapProvider == null)
        {
            Debug.LogError("LeapInputBridge could not find a LeapServiceProvider in the scene.", this);
        }
    }


    private void OnEnable()
    {
        if (leapProvider == null) return;
        leapProvider.OnUpdateFrame += OnLeapUpdateFrame;
    }
    private void OnDisable()
    {
        if (leapProvider == null) return;
        leapProvider.OnUpdateFrame -= OnLeapUpdateFrame;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    void OnLeapUpdateFrame(Frame frame)
    {
        foreach (var hand in frame.Hands)
        {
            if (hand.IsLeft)
            {
                handPositionL = hand.PalmPosition;
                palmNormalL = hand.PalmNormal;
                handVelocityL = hand.PalmVelocity;
            }
            else if (hand.IsRight)
            {
                handPositionR = hand.PalmPosition;
                palmNormalR = hand.PalmNormal;
                handVelocityR = hand.PalmVelocity;
            }
        }
    }


    #region public APIs
    public Vector3 GetHandPosition(HandSide side)
    {
        return side switch
        {
            HandSide.Left => handPositionL,
            HandSide.Right => handPositionR,
            _ => Vector3.zero,
        };
    }

    public Vector3 GetPalmNormal(HandSide side)
    {
        return side switch
        {
            HandSide.Left => palmNormalL,
            HandSide.Right => palmNormalR,
            _ => Vector3.zero,
        };
    }

    public Vector3 GetVelocity(HandSide side)
    {
        return side switch
        {
            HandSide.Left => handVelocityL,
            HandSide.Right => handVelocityR,
            _ => Vector3.zero,
        };
    }

    #endregion
}
