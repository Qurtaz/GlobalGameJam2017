using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public GameObject menu;
    public GameObject hightscore;
    public GameObject credits;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Highscore()
    {
        menu.SetActive(false);
        hightscore.SetActive(true);
    }
    public void Cresdits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }
    public void Close(GameObject close)
    {
        close.SetActive(false);
        menu.SetActive(true);
    }
}
