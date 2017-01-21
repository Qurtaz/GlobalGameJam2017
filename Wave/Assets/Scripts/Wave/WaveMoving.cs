﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMoving : MonoBehaviour
{

    Wave ThisWave;

    public GameObject[] States;

    public int speed = 10;
    public Vector3 Direct = new Vector3(0, 0, 1);

    
    public int MinimalHeightLimit = 2;
    public static bool rewind;
    Vector2 StartPosition;

    void Start()
    {
        rewind = false;
        StartPosition = new Vector2(this.transform.position.x, this.transform.position.z);
        ThisWave = GetComponent<Wave>();
    }

   

    void Update()
    {
        
        if (Wave.DistanceLimit < Vector2.Distance(StartPosition, new Vector2(this.transform.position.x, this.transform.position.z)) && rewind == false)
        {
            RewindWave();
        }

        if (rewind == true)
        {
            this.transform.Translate(Direct * -ThisWave.Speed / 10000);
        }
        else
        {
            this.transform.Translate(Direct * ThisWave.Speed / 10000);
        }
    }

    public void RewindWave()
    {
        States[0].SetActive(false);
        States[1].SetActive(true);
        rewind = true;
    }
}
