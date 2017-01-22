using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RndomeMaterial : MonoBehaviour {
    public List<Material> materialList;
    private MenagerBuilding men;
	
	void Start () {
        men = GetComponent<MenagerBuilding>();
        int d = Random.Range(0, materialList.Count);
        foreach (GameObject z in men.allFlors)
        {
            
            z.GetComponentInChildren<Renderer>().material = materialList[d];
        }
        men.Roof.GetComponentInChildren<Renderer>().material = materialList[d];

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
