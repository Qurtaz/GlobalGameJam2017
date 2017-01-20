using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    static int strength;
    public static int Strength
    {
        get
        {
            return strength;
        }
    }

    static int height;
    public static int Height // jako hp od pewnoego poziomu nie zmniejsza dmg
    {
        get
        {
            return height;
        }
    }

    static int speed;
    public static int Speed
    {
        get
        {
            return Speed;
        }
    }

    static int score;
    public static int Score
    {
        get
        {
            return score;
        }
    }

    public void GeneratObstacel(int builgingLevel) //uderzyl w budynek
    {

    }

    public void GeneratObstacel(int builgingLevel, int addisionForse) //uderzyl w przeszkode
    {

    }

}
