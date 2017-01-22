using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBuilding : Cities {
   

    public static float incomeWeight = 0.1f;

    public int ActualLevel;
	// Use this for initialization
	void Start () {
        maxHP = 100;
        hp = maxHP;
        maxFortificationlevel = 3;
        maxBuildingLevel = 3;
        //builgingLevel = 0;
        fortificationLevet = 0;
        stamina = 0.70f;
        upgrade = false;
        maxPeople = (builgingLevel+1) * 15;
        currentPeople = maxPeople;
        generateMoney = currentPeople*incomeWeight;
        //data = GetComponent<MenagerBuilding>();
        LevelEvents.EndLevel += AddMoney;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddMoney()
    {
        Resources.ChangeMoney(50);
    }

    public override void Work(GameObject Vawe)
    {
        Debug.Log("builgingLevel = " + builgingLevel.ToString());
        Vawe.GetComponent<Wave>().GeneratObstacel(builgingLevel);
    }

    void OnDestroy()
    {
        LevelEvents.EndLevel -= AddMoney;
    }
}
