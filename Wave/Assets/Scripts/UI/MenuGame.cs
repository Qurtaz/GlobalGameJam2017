using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour {
    public GameObject building;
    public GameObject trap;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartBuildingBuild()
    {
        building.SetActive(true);
    } 

    public void StartBuildingTrap()
    {
        trap.SetActive(true);
    }
    public void Close(GameObject close)
    {
        close.SetActive(false);
    }
    public void CloseGame()
    {
        SceneManager.LoadScene(0);
    }
}
