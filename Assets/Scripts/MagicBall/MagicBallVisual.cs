using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBallVisual : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ParticleSystem head;
    [SerializeField] private ParticleSystem particle;

    private void Start()
    {
        SetColor(new Color(0.5f, 0.5f, 0.5f, 1f));

        ParticleSystem[] allPS = GetComponentsInChildren<ParticleSystem>();
        foreach (var ps in allPS)
        {
            var main = ps.main;
            main.useUnscaledTime = true;
        }
    }

    public void SetColor(Color color)
    {
        // Set head color
        var headMain = head.main;
        headMain.startColor = color;

        // Set particle color
        var particleMain = particle.main;
        particleMain.startColor = color;
    }
}
