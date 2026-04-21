using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [Header("Animation Settings")]
    [SerializeField] private float floatSpeed = 0.5f;
    [SerializeField] private float fadeDuration = 0.8f;

    private float _timer = 0f;
    private Color _color;

    public void Init(float damage, Color color)
    {
        Debug.Log("DamageNumber Init: " + damage);
        _color = color;
        text.text = Mathf.RoundToInt(damage).ToString();
        text.color = _color;
    }

    private void Update()
    {
        // floating upwards
        transform.position += floatSpeed * Time.unscaledDeltaTime * Vector3.up;

        // fade
        _timer += Time.unscaledDeltaTime;
        float alpha = Mathf.Lerp(1f, 0f, _timer / fadeDuration);
        text.color = new Color(_color.r, _color.g, _color.b, alpha);

        if (_timer >= fadeDuration)
        {
            Debug.Log("DamageNumber Destroyed");
            Destroy(gameObject);
        }
    }
}
