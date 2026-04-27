using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/AreaConfig")]
public class AreaConfig : ScriptableObject
{
    public int areaID;
    public List<StageConfig> stageConfigs;
}
