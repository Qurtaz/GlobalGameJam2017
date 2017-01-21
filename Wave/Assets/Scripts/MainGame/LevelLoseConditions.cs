using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoseConditions : MonoBehaviour {


    public string BuldingsTag;
	// Use this for initialization
	void Start () {
        LevelEvents.EndLevel += Check;
	}
	
	void Check()
    {
        GameObject[] Buldings = GameObject.FindGameObjectsWithTag(BuldingsTag);
        if(Buldings.Length == 0)
        {
            LevelEvents.SetState(LevelEvents.States.EndGame);
        }
    }
}
