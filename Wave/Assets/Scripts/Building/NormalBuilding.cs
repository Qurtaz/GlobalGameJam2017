using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBuilding : Cities {
    public MenagerBuilding data;
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
        //data = GetComponent<MenagerBuilding>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetLevelBuilding(int z)
    {
        builgingLevel = z;
        data.Refresh();
    }
}
