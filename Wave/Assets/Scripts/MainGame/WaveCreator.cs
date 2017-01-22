using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCreator : MonoBehaviour {

    public GameObject WaveObj;
    public Vector2 StartPosition;
    public float RandomizeRange = 0.2f;
    public int Height;
    public Sounds sounds;


    void Start () {
        //CreateIncomingWaves(5, 2);
	}
	
	public void CreateIncomingWaves(float HeightWaves, int WaveStrength)
    {
        GameObject NewWave;
        sounds.PlayeWave();
        for(int i = 0; i < TerrainGenerator.width ; i++)
        {
            NewWave = Instantiate(WaveObj, new Vector3(i + StartPosition.x, Height, StartPosition.y) , transform.rotation) as GameObject;
            NewWave.GetComponent<Wave>().Height = HeightWaves + Random.Range(-RandomizeRange, RandomizeRange);
            NewWave.GetComponent<Wave>().Strength = WaveStrength;
        }
    }
}
