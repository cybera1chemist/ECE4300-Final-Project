using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI timeText;

    private float stageMaxMinute;

    private float _timer = 0f;
    private bool stageCompleted = false;

    void Start()
    {
        stageMaxMinute = AreaManager.Instance.GetCurStageConfig().maxTimeMinute;
        _timer = stageMaxMinute * 60f + 1f;
    }

    void Update()
    {
        if (stageCompleted) return;
        _timer -= Time.deltaTime;
        int minutes = (int)(_timer / 60);
        int seconds = (int)(_timer % 60);
        timeText.text = $"{minutes:D2} : {seconds:D2}";

        if (_timer <= 0f){
            stageCompleted = true;
            AreaManager.Instance.StageComplete();  
        }
    }
}
