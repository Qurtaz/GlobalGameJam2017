using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlace : MonoBehaviour {

    public GameObject[] Waters;
    public GameObject[] Beaches;
    public GameObject[] Landes;
    public GameObject[] Speciales;

    // Use this for initialization
    void Start () {
        StartCoroutine("Delay");
	}
	
    IEnumerator Delay()
    {
        yield return new WaitForEndOfFrame();
        Waters = GameObject.FindGameObjectsWithTag("WaterTile");
        Beaches = GameObject.FindGameObjectsWithTag("BeachTile");
        Landes = GameObject.FindGameObjectsWithTag("LandTile");
        Speciales =  GameObject.FindGameObjectsWithTag("SpecialTile");

    }


    public void SetOn(int wchich)
    {
        Debug.Log("Switcher!");
        switch (wchich)
        {
            case 1:
                SwitchS(Waters, true);
                break;
            case 2:
                SwitchS(Beaches, true);
                break;
            case 3:
                SwitchS(Landes, true);
                break;
            case 4:
                SwitchS(Speciales, true);
                break;
        }
    }

	public void SwitchOffAll()
    {
        SwitchS(Waters, false);
        SwitchS(Beaches, false);
        SwitchS(Landes, false);
        SwitchS(Speciales, false);
    }

    public void SwitchS(GameObject[] tab, bool state)
    {
        
        for (int i = 0; i < tab.Length; i++)
        {
            tab[i].GetComponent<MeshRenderer>().enabled = state;
        }
    }
}
