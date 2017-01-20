﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollider : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Buldings")
        {
            other.gameObject.SendMessage("Work", GetComponent<Wave>().Strength + GetComponent<Wave>().Height);
        }
    }
}