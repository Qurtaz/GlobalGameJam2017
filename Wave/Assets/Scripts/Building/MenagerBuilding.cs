using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenagerBuilding : MonoBehaviour {
    public GameObject groundFloor;
    public GameObject middelFloor;
    public GameObject lastFloor;
    private Building building;
    public List<GameObject> allFlors;
    // Use this for initialization
    void Start () {
        building = gameObject.GetComponent<Building>();
        allFlors = new List<GameObject>();
        allFlors.Add(Instantiate(groundFloor, gameObject.transform.position, gameObject.transform.rotation));
        allFlors.Add(Instantiate(lastFloor, gameObject.transform.position, gameObject.transform.rotation));
        for(int i =0; i <= building.GetLevelBuilding(); i++)
        {
            allFlors.Insert(1, (Instantiate(middelFloor, gameObject.transform.position, gameObject.transform.rotation)));
        }
        Operaction();
	}
	
	// Update is called once per frame
	public void Operaction () {
        //while(!(allFlors.Count < building.GetLevelBuilding() + 2))
        //{
        //    allFlors.Insert(1, (Instantiate(middelFloor, gameObject.transform.position, gameObject.transform.rotation)));
        //}
        for(int i = 0; i <= allFlors.Count;i++)
        {
            for(int z =1; z <=allFlors.Count - i;z++)
            {
                CorectHight(z);
            }
        }
		
	}
    public void CorectHight(int i)
    {
        if(allFlors[i-1].transform.position == allFlors[i].transform.position)
        {
            allFlors[i].transform.position = new Vector3(allFlors[i].transform.position.x, allFlors[i].transform.position.y + 1, allFlors[i].transform.position.z);
        }
        if(allFlors[i].transform.position.y - allFlors[i-1].transform.position.y >1)
        {
            allFlors[i].transform.position = new Vector3(allFlors[i].transform.position.x, allFlors[i].transform.position.y - 1, allFlors[i].transform.position.z);
        }
    }
}
