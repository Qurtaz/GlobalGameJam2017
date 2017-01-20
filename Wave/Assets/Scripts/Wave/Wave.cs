using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    int strength;
    public int Strength
    {
        get
        {
            return strength;
        }
    }

    int height;
    public int Height // jako hp od pewnoego poziomu nie zmniejsza dmg
    {
        get
        {
            return height;
        }
    }

    int speed;
    public int Speed
    {
        get
        {
            return Speed;
        }
    }

}
