using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : Obstacel {

	// Use this for initialization
	void Start () {
        maxHP = 100;
        hp = maxHP;
        maxFortificationlevel = 3;
        maxBuildingLevel = 3;
        builgingLevel = 0;
        fortificationLevet = 0;
        stamina = 0.6f;
        addisionForse = 40;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
