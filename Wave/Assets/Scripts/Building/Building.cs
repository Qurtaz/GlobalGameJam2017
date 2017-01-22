﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour {
    public float maxHP;
    protected float hp;
    protected int builgingLevel;
    protected int fortificationLevet;
    protected int maxBuildingLevel;
    protected int maxFortificationlevel;
    protected float cost;
    protected float stamina;
    protected MenagerBuilding menager;
    // Use this for initialization
    void Start () {
        hp = maxHP;
        menager = GetComponent<MenagerBuilding>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MinuesHP(float z)
    {
        hp = hp - stamina*z;
        if (hp <= 0)
        {
            if (builgingLevel >= 0)
            {
                builgingLevel--;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    public virtual void  Work(GameObject Vawe)
    {

    }
    public float GetHP()
    {
        return hp;
    }
    public int GetLevelBuilding()
    {
        return builgingLevel;
    }
    public void UpgardeFortification(float z)
    {
        stamina -= z;
        fortificationLevet++;
    }
    public void UpgradeBuilding()
    {
        
        builgingLevel++;
        hp = maxHP;
        menager.Refresh();
       
    }
    public virtual bool CanUpgradeBuinding()
    {
        if (builgingLevel < maxBuildingLevel)
            return true;
        else
            return false;
    }
    public virtual bool CanUpgradeFortifiactiong()
    {
        if (fortificationLevet < maxFortificationlevel)
            return true;
        else
            return false;
    }
}
