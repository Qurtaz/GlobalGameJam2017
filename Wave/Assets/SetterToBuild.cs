﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterToBuild : MonoBehaviour {

public GameObject[] prefabs;
    GameObject toSend;
    int TypeToSend;
    int CostToSend;

public GameObject rayObject;
    public GameObject Show;

    public void ToSetIndexPrefab(int a)
    {
        toSend = prefabs[a];
    }

public void ToSetType(int a)
    {
        TypeToSend=a;
    }

public void ToSetCost(int a)
    {
        CostToSend = a;
    }

public void Sending()
    {
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForEndOfFrame();
        Show.GetComponent<ShowPlace>().SwitchOffAll();
        if (Resources.Money >= CostToSend)
        {
            
            rayObject.GetComponent<MasterController>().typeOfBuilding = TypeToSend;
            rayObject.GetComponent<MasterController>().toBuild = toSend;
            rayObject.GetComponent<MasterController>().buildingCost = CostToSend;
            Show.GetComponent<ShowPlace>().SetOn(TypeToSend);
        }
        else
        {
            Message.Set("You don't have enough money");
        }
        
    }


}
