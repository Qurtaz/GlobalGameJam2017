using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBuilding : Cities {

	// Use this for initialization
	void Start () {
        maxHP = 100;
        hp = maxHP;
        generateMoney = 5;
        maxFortificationlevel = 3;
        maxBuildingLevel = 3;
        builgingLevel = 0;
        fortificationLevet = 0;
        stamina = 1;
        upgrade = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
