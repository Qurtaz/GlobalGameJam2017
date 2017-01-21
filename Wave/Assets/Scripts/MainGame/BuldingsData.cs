using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuldingsData : MonoBehaviour {

    public const int MaxUpdateLevel = 3;
    public const int CountofTypeBuilding = 3;
    public static BuildingInfo[] Special = new BuildingInfo[CountofTypeBuilding];



    void Awake()
    {

    }

}


public class BuildingInfo
{
    public Texture Icon;
    public int BuildCost;
    public int[] UpgradeCosts = new int[BuldingsData.MaxUpdateLevel];
    public int[] ObstacleStrength = new int[BuldingsData.MaxUpdateLevel];

    public BuildingInfo(Texture _icon, int[] _costs)
    {
        Icon = _icon;
        for(int i = 0; i < BuldingsData.MaxUpdateLevel; i++)
        {
            ObstacleStrength[i] = 0;
            UpgradeCosts[i] = _costs[i];
        }
    }

    public BuildingInfo(Texture _icon, int[] _costs, int[] _obstacleStrength)
    {
        Icon = _icon;
        for (int i = 0; i < BuldingsData.MaxUpdateLevel; i++)
        {
            ObstacleStrength[i] = _obstacleStrength[i];
            UpgradeCosts[i] = _costs[i];
        }
    }


}
