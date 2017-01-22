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
        for (int i = 0; i < 1; i++)
        {
            Debug.Log("BlaBla");
            //yield return new WaitForSeconds(DelayWaveTime - (ActualLevel));
            yield return new WaitForSeconds(0.2f);
            WC.CreateIncomingWaves(2.5f + ActualLevel*0.3f, 2); 
        }
        while (true)
        {
            yield return new WaitForSeconds(2);
            GameObject[] Waves = GameObject.FindGameObjectsWithTag("Wave");
            if (Waves.Length == 0)
            {
                break;
            }
            Debug.Log("PrawieKoniec");
        }
        IsWaveIncoming = false;
        LevelEvents.SetState(LevelEvents.States.EndLvl);
        ActualLevel++;

    }

    

}

