﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cities : Building {
    public float generateMoney;
    public bool upgrade;
    public int maxPeople;
    public int currentPeople; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void UpgradeBuilding()
    {
        base.UpgradeBuilding();
        maxPeople += 15;
    }
    
    public void AddMoney()
    {
        Resources.ChangeMoney((int)(generateMoney + generateMoney*builgingLevel));
    }
    public override bool CanUpgradeBuinding()
    {
        if (upgrade)
            return base.CanUpgradeBuinding();
        else
            return upgrade;
    }
    public override float Income()
    {
        return base.Income()+ generateMoney;
    }
}
