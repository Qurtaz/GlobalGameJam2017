using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBags : Obstacel {

	// Use this for initialization
	void Start () {
        maxHP = 100;
        hp = maxHP;
        maxFortificationlevel = 3;
        maxBuildingLevel = 3;
        builgingLevel = 0;
        fortificationLevet = 0;
        stamina = 0.8f;
        addisionForse = 20;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
