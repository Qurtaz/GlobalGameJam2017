using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RndomeMaterial : MonoBehaviour {
    public List<Material> materialList;
    private MenagerBuilding men;
	// Use this for initialization
	void Start () {
        int d  = (int)Random.Range(0, materialList.Count);
        foreach(GameObject z in men.allFlors)
        {
            z.GetComponent<Renderer>().material = materialList[d];
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
