using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : Cities {

	// Use this for initialization
	void Start () {
        maxHP = 100;
        hp = maxHP;
        generateMoney = 30.5f;
        maxFortificationlevel = 3;
        maxBuildingLevel = 3;
        builgingLevel = 0;
        fortificationLevet = 0;
        stamina = 0.95f;
        upgrade = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
