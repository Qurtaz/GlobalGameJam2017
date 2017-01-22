using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenager : MonoBehaviour {

    public WaveCreator WC;

    public int ActualLevel = 1;

    public int DelayWaveTime = 10;

    public static bool IsWaveIncoming = false;

    void Start()
    {
        LevelEvents.StartLevel += CreateWaves;
    }

    public void CreateWaves()
    {
        StartCoroutine("LevelsCome");
    }

    IEnumerator LevelsCome()
    {
        IsWaveIncoming = true;
        for (int i = 0; i < ActualLevel + 1; i++)
        {
            yield return new WaitForSeconds(DelayWaveTime - (ActualLevel));
            WC.CreateIncomingWaves(2 + ActualLevel*0.3f, 2); 
        }
        IsWaveIncoming = false;


    }

    

}

