using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollider : MonoBehaviour {

    Wave ThisWave;

    void Start()
    {
        ThisWave = transform.parent.GetComponent<Wave>();
    }
    

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Kolizja");
        if(other.tag == "Bulding")
        {   
            other.gameObject.SendMessage("MinuesHP", ThisWave.Strength + ThisWave.Height);
            other.gameObject.SendMessage("Work", transform.parent.gameObject);
        }
    }
}
