using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/StageConfig")]
public class StageConfig : ScriptableObject
{
    public int belongToArea;
    public int stageID;

    public float maxTimeMinute = 1f;

    public List<SpawnEvent> spawnEvents;
}
