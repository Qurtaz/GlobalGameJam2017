using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBuilding : Cities {
    public MenagerBuilding data;
    public int ActualLevel;
	// Use this for initialization
	void Start () {
        maxHP = 100;
        hp = maxHP;
        generateMoney = 5;
        maxFortificationlevel = 3;
        maxBuildingLevel = 3;
        //builgingLevel = 0;
        fortificationLevet = 0;
        stamina = 0.70f;
        upgrade = false;
        maxPeople = 15 + builgingLevel * maxPeople;
        //data = GetComponent<MenagerBuilding>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetLevelBuilding(int z)
    {
        builgingLevel = z;
        Debug.Log("Set builgingLevel = " + builgingLevel.ToString());
        data.Refresh();
    }

    public override void Work(GameObject Vawe)
    {
        Debug.Log("builgingLevel = " + builgingLevel.ToString());
        Vawe.GetComponent<Wave>().GeneratObstacel(builgingLevel);
    }
}
