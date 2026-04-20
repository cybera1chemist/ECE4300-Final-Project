using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [Header("Animation Settings")]
    [SerializeField] private float floatSpeed = 1.5f;
    [SerializeField] private float fadeDuration = 0.8f;

    private float _timer;
    private Color _color;

    public void Init(float damage, Color color)
    {
        _color = color;
        text.text = Mathf.RoundToInt(damage).ToString();
        text.color = _color;
    }

    private void Update()
    {
        // floating upwards
        transform.position += floatSpeed * Time.deltaTime * Vector3.up;

        // fade
        _timer += Time.deltaTime;
        float alpha = Mathf.Lerp(1f, 0f, _timer / fadeDuration);
        text.color = new Color(_color.r, _color.g, _color.b, alpha);

        if (_timer >= fadeDuration)
        {
            Destroy(gameObject);
        }
    }
}
