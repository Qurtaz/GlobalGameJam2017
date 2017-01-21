using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cityhall : Cities {

	// Use this for initialization
	void Start () {
        maxHP = 100;
        hp = maxHP;
        generateMoney = 20;
        maxFortificationlevel = 3;
        maxBuildingLevel = 3;
        builgingLevel = 0;
        fortificationLevet = 0;
        stamina = 1;
        upgrade = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
