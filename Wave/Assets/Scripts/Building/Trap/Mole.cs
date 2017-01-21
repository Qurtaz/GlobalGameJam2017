using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : Obstacel {

	// Use this for initialization
	void Start () {
        maxHP = 100;
        hp = maxHP;
        maxFortificationlevel = 3;
        maxBuildingLevel = 3;
        builgingLevel = 0;
        fortificationLevet = 0;
        stamina = 0.4f;
        addisionForse = 50;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
