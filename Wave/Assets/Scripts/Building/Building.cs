using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    protected string description;
    protected Image image;
    // Use this for initialization
    void Start () {
        hp = maxHP;
        menager = GetComponent<MenagerBuilding>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Image GetImage()
    {
        return image;
    }
    public float GetStatima()
    {
        return stamina;
    }
    public string GetDesription()
    {
        return description;
    }
    public float GetHP()
    {
        return (int)hp;
    }
    public float GetMaxHP()
    {
        return maxHP;
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
        Vawe.GetComponent<Wave>().GeneratObstacel(builgingLevel);
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
    virtual public void UpgradeBuilding()
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
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public virtual float Income()
    {
        return -cost;
    }
}
