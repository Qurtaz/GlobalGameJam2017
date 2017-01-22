using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Obstacel {

	// Use this for initialization
	void Start () {
        maxHP = 100;
        hp = maxHP;
        maxFortificationlevel = 3;
        maxBuildingLevel = 3;
        builgingLevel = 0;
        fortificationLevet = 0;
        stamina = 0.7f;
        addisionForse = 35;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
