using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenagerBuilding : MonoBehaviour {
    public GameObject groundFloor;
    public GameObject middelFloor;
    public GameObject lastFloor;
    public GameObject Roof;
    public GameObject RoofAddon;
    public Building building;
    public List<GameObject> allFlors;

    void Awake() {     
        allFlors = new List<GameObject>(); 
    }

    public void Refresh()
    {
        for (int i = 0; i < allFlors.Count; i++)
        {
            Destroy(allFlors[i]);
            
        }
        allFlors = new List<GameObject>();
        if (building.GetLevelBuilding() == 0)
        {
            allFlors.Add(Instantiate(groundFloor, gameObject.transform.position, gameObject.transform.rotation)); 
            allFlors[0].transform.parent = gameObject.transform;
            Roof.transform.position = new Vector3(gameObject.transform.position.x, 0.5f, gameObject.transform.position.z);
            return;
        }
            allFlors.Add(Instantiate(groundFloor, gameObject.transform.position, gameObject.transform.rotation)); 
            allFlors[0].transform.parent = gameObject.transform;
            int ActualLevel = 1;
            while (ActualLevel < building.GetLevelBuilding())
            {
                allFlors.Add(Instantiate(middelFloor, new Vector3(gameObject.transform.position.x, ActualLevel + 0.5f, gameObject.transform.position.z), gameObject.transform.rotation));
                allFlors[ActualLevel].transform.parent = gameObject.transform;
                ActualLevel++;
            }
            GameObject tmp = Instantiate(lastFloor, new Vector3(gameObject.transform.position.x, ActualLevel + 0.5f, gameObject.transform.position.z), gameObject.transform.rotation);
            allFlors.Add(tmp);
            allFlors[ActualLevel].transform.parent = gameObject.transform;

        Roof.transform.position = new Vector3(gameObject.transform.position.x, ActualLevel + 0.5f, gameObject.transform.position.z);

    }

    /*void Start () {
        building = gameObject.GetComponent<Building>();
        allFlors = new List<GameObject>();
        if(building.GetLevelBuilding() == 0)
        {
           // allFlors.Add(Instantiate(groundFloor, gameObject.transform.position, gameObject.transform.rotation));
            //allFlors[0].transform.parent = gameObject.transform;
        }
        else
        {
            //allFlors.Add(Instantiate(groundFloor, gameObject.transform.position, gameObject.transform.rotation));
            //allFlors[0].transform.parent = gameObject.transform;
            allFlors.Add(Instantiate(lastFloor, gameObject.transform.position, gameObject.transform.rotation));
            allFlors[1].transform.parent = gameObject.transform;
            for (int i = 2; i <= building.GetLevelBuilding(); i++)
            {
                allFlors.Insert(1, (Instantiate(middelFloor, gameObject.transform.position, gameObject.transform.rotation)));
                allFlors[1].transform.parent = gameObject.transform;
            }
        }
        //allFlors.Add(Instantiate(flore, gameObject.transform.position, gameObject.transform.rotation));
        //allFlors[allFlors.Count - 1].transform.parent = gameObject.transform;
        Operaction();
	}
	
	// Update is called once per frame
	public void Operaction () {
        Add();
        while ((allFlors.Count > building.GetLevelBuilding() + 1))
        {
            Debug.Log("Polska");
            GameObject a = allFlors[1];
            allFlors.RemoveAt(1);
            Destroy(a);
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
        if(allFlors[1] == flore)
        {
            allFlors[i].transform.position = new Vector3(allFlors[i - 1].transform.position.x, allFlors[i - 1].transform.position.y-1, allFlors[i - 1].transform.position.z);
        }
    }

    private void Add()
    {
        while ((allFlors.Count < building.GetLevelBuilding() + 1))
        {
            Debug.Log("już jest");
            if (allFlors.Count < 2)
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
    }*/
}
