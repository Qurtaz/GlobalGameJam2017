using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterToBuild : MonoBehaviour {

public GameObject[] prefabs;
    GameObject toSend;
    int TypeToSend;
    int CostToSend;

public GameObject rayObject;

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
        rayObject.GetComponent<MasterController>().typeOfBuilding = TypeToSend;
        rayObject.GetComponent<MasterController>().toBuild = toSend;
        rayObject.GetComponent<MasterController>().buildingCost = CostToSend;
    }


}
