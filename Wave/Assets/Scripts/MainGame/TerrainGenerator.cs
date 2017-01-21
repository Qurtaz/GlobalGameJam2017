using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    public GameObject Land;
    public GameObject[] Beach;
    public GameObject Water;
    public GameObject Earth;

    public const int width = 12;

    public const int WaterLenght = 3;
    public const int LandLenght = 12;

    void Start () {
        Generate();
	}

    void PartGenerator(GameObject What, int Length, int StartPosition, int height = 0)
    {
        for (int j = 0; j < Length; j++)
        {
            for (int i = 0; i < width; i++)
            {
                Instantiate(What, new Vector3(i, height, j+StartPosition), transform.rotation);
                if(height > 0)
                {
                    for(int k = height - 1; k >= 0; k--)
                    {
                        Instantiate(Earth, new Vector3(i, k, j + StartPosition), transform.rotation);
                    }
                }
            }
        }

    }

    void Generate()
    {
        int ActualPosition = 0;
        
        PartGenerator(Water, WaterLenght, ActualPosition);
        ActualPosition += WaterLenght;

        for(int i = 0; i < Beach.Length; i++)
        {
            PartGenerator(Beach[i], 1, ActualPosition,1);
            ActualPosition++;
        }

        PartGenerator(Land, LandLenght, ActualPosition, 1);
    }

    
}
