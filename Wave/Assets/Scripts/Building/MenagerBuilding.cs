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

    void Awake() {
        allFlors.Clear();
    }
    void Start () {
        building = gameObject.GetComponent<Building>();
        allFlors = new List<GameObject>();
        if(building.GetLevelBuilding() == 0)
        {
            allFlors.Add(Instantiate(groundFloor, gameObject.transform.position, gameObject.transform.rotation));
            allFlors[0].transform.parent = gameObject.transform;
        }
        else
        {
            allFlors.Add(Instantiate(groundFloor, gameObject.transform.position, gameObject.transform.rotation));
            allFlors[0].transform.parent = gameObject.transform;
            allFlors.Add(Instantiate(lastFloor, gameObject.transform.position, gameObject.transform.rotation));
            allFlors[1].transform.parent = gameObject.transform;
            for (int i = 2; i <= building.GetLevelBuilding(); i++)
            {
                allFlors.Insert(1, (Instantiate(middelFloor, gameObject.transform.position, gameObject.transform.rotation)));
                allFlors[1].transform.parent = gameObject.transform;
            }
        }
        
        Operaction();
	}
	
	// Update is called once per frame
	public void Operaction () {
        while ((allFlors.Count < building.GetLevelBuilding() + 1))
        {
            if(allFlors.Count <2 )
            {
                allFlors.Add(Instantiate(groundFloor, gameObject.transform.position, gameObject.transform.rotation));
                allFlors[0].transform.parent = gameObject.transform;
                allFlors.Add(Instantiate(lastFloor, gameObject.transform.position, gameObject.transform.rotation));
                allFlors[1].transform.parent = gameObject.transform;
                for (int i = 1; i <= building.GetLevelBuilding(); i++)
                {
                    allFlors.Insert(1, (Instantiate(middelFloor, gameObject.transform.position, gameObject.transform.rotation)));
                    allFlors[1].transform.parent = gameObject.transform;
                }
            }
            else
            {
                allFlors.Insert(1, (Instantiate(middelFloor, gameObject.transform.position, gameObject.transform.rotation)));
                allFlors[1].transform.parent = gameObject.transform;
            }   
        }
        while ((allFlors.Count > building.GetLevelBuilding() + 1))
        {
            allFlors.RemoveAt(1);
        }
        for (int i = 0; i < allFlors.Count;i++)
        {
            for(int z = allFlors.Count-1; z >0;z--)
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
