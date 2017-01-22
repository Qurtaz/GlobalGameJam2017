using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBuilding : Cities {
    public MenagerBuilding data;
    public static float incomeWeight = 0.1f;

	// Use this for initialization
	void Start () {
        maxHP = 100;
        hp = maxHP;
        maxFortificationlevel = 3;
        maxBuildingLevel = 3;
        builgingLevel = 0;
        fortificationLevet = 0;
        stamina = 0.70f;
        upgrade = false;
        maxPeople = (builgingLevel+1) * 15;
        //currentPeople = maxPeople;
        //generateMoney = currentPeople*incomeWeight;
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
