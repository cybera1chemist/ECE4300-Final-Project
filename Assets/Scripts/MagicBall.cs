using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MagicBall : MonoBehaviour
{
    [Header("Magic Ball Config")]
    [SerializeField] private float distanceFromPalm = 0.2f;
    [SerializeField] private float lifetime = 5f;

    [Header("Color Config")]
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    [SerializeField] private float maxZ;

    [Header("References")]
    [SerializeField] private MagicBallVisual visual;

    public bool launched = false;

    private Color curColor;
    // For debug only, I want to see delta and color change in the editor
    public Vector3 delta;
    private HandSide side;

    private Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }

    private void Update()
    {
        if (launched)
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0f)  Destroy(gameObject);
        } else
        {
            delta = transform.position - initialPos;
            SetColor(MapColor(delta));
        }
    }

    private Color MapColor(Vector3 delta)
    {   
        float r;
        if (side == HandSide.Right)  r = 0.5f - delta.x / maxX;
        else  r = 0.5f + delta.x / maxX;
        float g = 0.5f - delta.y / maxY;
        float b = 0.5f - delta.z / maxZ;
        return new Color(r, g, b, 1f);
    }

    #region Public APIs
    public void SetColor(Color color)
    {
        if (launched) return;
        visual.SetColor(color);
        curColor = color;
    }
    public Color GetColor() => curColor;

    public void SetSide(HandSide handSide) => side = handSide;
    public void UpdatePosition(Vector3 palmPosition, Vector3 palmNormal)
    {
        if (launched) return;
        transform.position = palmPosition + palmNormal.normalized * distanceFromPalm;
    }

    public void Launch(Vector3 velocity)
    {        
        if (launched) return;
        launched = true;

        // Add velocity to the ball
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = velocity;
        
        // Add other effects later (e.g., particle, sound)
    }

    public void Cancel()
    {
        if (launched) return;
        Destroy(gameObject);
    }

    #endregion
}
