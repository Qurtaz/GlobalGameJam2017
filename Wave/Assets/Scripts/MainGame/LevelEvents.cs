using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEvents : MonoBehaviour {
    public delegate void LevelState();

    public static event LevelState StartLevel;
    public static event LevelState EndLevel;
    public static event LevelState EndMatch;

    // Use this for initialization
    void Start () {
		
	}
	
	void OnMatchEnd()
    {
        StartLevel = null;
        EndLevel = null;
        EndMatch = null;
    }
    public enum States {StartLvL,EndLvl,EndGame};

    public void StartMatch()
    {
        SetState(States.StartLvL);
    }

    public static void SetState(States ToSet)
    {
        if (LevelMenager.IsWaveIncoming)
        {
            return;
        }
        switch (ToSet)
        {
            case States.StartLvL:
                StartLevel();
                break;
            case States.EndLvl:
                StartLevel();
                break;
            case States.EndGame:
                StartLevel();
                break;
        }
    }

    

}
