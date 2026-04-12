using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    public StageConfig config;
    public EnemyDatabase enemyDB;
    [SerializeField] private Transform spawnPoint;
    
    [Header("Settings")]
    public int maxSpawnCount = 50;
    [SerializeField] private float roadWidth = 0.2f;

    private int totalEnemy = 0;

    private float timer = 0f;
    private readonly Dictionary<SpawnEvent, float> nextSpawnTime = new();

    private void Start()
    {
        foreach (var evt in config.spawnEvents)
        {
            // 对于循环生成事件，安排下一次生成时间
            nextSpawnTime[evt] = evt.startMinute * 60f;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        foreach (var evt in config.spawnEvents)
        {
            // 时间不到开始时间
            if (timer < evt.startMinute * 60f)  continue;

            // Boss / spawnOnce 事件
            if (evt.spawnOnce)
            {
                if (timer >= evt.startMinute * 60f && nextSpawnTime[evt] >= 0f)
                {
                    SpawnEnemy(evt);
                    nextSpawnTime[evt] = -1f; // 标记已经执行过
                }
                continue;
            }

            // 普通循环事件结束
            if (timer > evt.endMinute * 60f)
                continue;

            // 判断是否到了生成时间
            if (timer >= nextSpawnTime[evt] && totalEnemy < maxSpawnCount)
            {
                SpawnEnemy(evt);
                nextSpawnTime[evt] += evt.spawnInterval;
            }
        }
    }

    private void SpawnEnemy(SpawnEvent evt)
    {
        var data = enemyDB.GetEnemy(evt.enemyId);
        if (!data)
        {
            Debug.LogWarning("No EnemyData found for id: " + evt.enemyId);
            return;
        }

        for (int i = 0; i < evt.spawnCount; i++)
        {
            float offsetX = Random.Range(-roadWidth / 2f, roadWidth / 2f);
            Vector3 pos = spawnPoint.position + new Vector3(offsetX, 0f, 0f);

            Instantiate(data.prefab, pos, Quaternion.identity);
        }
    }

    #region public API
    public void AddTotalEnemy() => totalEnemy++;
    public void RemoveTotalEnemy() => totalEnemy--;

    public void SpawnSingleEnemy(int enemyId)
    {
        var data = enemyDB.GetEnemy(enemyId);
        if (!data)
        {
            Debug.LogWarning("No EnemyData found for id: " + enemyId);
            return;
        }

        float offsetX = Random.Range(-roadWidth / 2f, roadWidth / 2f);
        Vector3 pos = spawnPoint.position + new Vector3(offsetX, 0f, 0f);

        Instantiate(data.prefab, pos, Quaternion.identity);
    }
    #endregion
}
