using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    public GameObject Land;
    public GameObject[] Beach;
    public GameObject Water;

    public GameObject WaterT;
    public GameObject BeachT;
    

    public GameObject Reef;

    public const int width = 12;

    public const int WaterLenght = 5;
    public const int LandLenght = 12;

    public int FieldsWaterLength = 3;

    void Start () {
        Generate();
	}

    void PartGenerator(GameObject What,  int Length, int StartPosition, float height = 0)
    {
        for (int j = 0; j < Length; j++)
        {
            for (int i = 0; i < width; i++)
            {
                Instantiate(What, new Vector3(i, height, j+StartPosition), transform.rotation); 
            }
        }

    }

    



    void Generate()
    {
        int ActualPosition = 0;
        
        PartGenerator(Water, WaterLenght+2, ActualPosition);
        PartGenerator(Reef, WaterLenght, ActualPosition);
        PartGenerator(WaterT, FieldsWaterLength, ActualPosition + WaterLenght - FieldsWaterLength,0.5f);
        ActualPosition += WaterLenght;

        for(int i = 0; i < Beach.Length; i++)
        {
            PartGenerator(Beach[i], 1, ActualPosition);
            if(i != 0)
            {
                PartGenerator(BeachT, 1, ActualPosition,1);
            }
            ActualPosition++;
        }

        PartGenerator(Land, LandLenght, ActualPosition);
        


    }

    

    
}
