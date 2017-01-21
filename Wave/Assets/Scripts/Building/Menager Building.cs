using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenagerBuilding : MonoBehaviour {
    public GameObject groundFloor;
    public GameObject middelFloor;
    public GameObject lastFloor;
    private Building building;
    // Use this for initialization
    void Start () {
        building = gameObject.GetComponent<Building>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
