using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public int length = 10;
    public int width = 10;

    public int OffsetGeneratorX = 0;
    public int OffsetGeneratorZ = 0;

    public GameObject PrefabRoad;
    public GameObject PrefabBuilding;
    public GameObject PrefabFoundation;

    public int Height = 2;

    void Start()
    {
        Generate();
    }

    void Generate()
    {
        for(int i = 0; i < length; i++)
        {
            if(i%2 == 0)
            {
                for (int j = 0; j < width; j++)
                {
                    Instantiate(PrefabRoad, GetPosition(i, j), transform.rotation);
                }
                
            }
            else
            {
                int Road = Random.Range(2, width - 1);
                int Foundation = Random.Range(1, width - 1);
                if(Foundation == Road)
                {
                    Foundation++;
                }
                for (int j = 0; j < width; j++)
                {
                    if (j == 0 || j == width - 1)
                    {
                        Instantiate(PrefabRoad, GetPosition(i, j), transform.rotation);
                    }
                    else
                    {
                        if(j == Road)
                        {
                            Instantiate(PrefabRoad, GetPosition(i, j), transform.rotation);
                        }
                        else if (Foundation == j)
                        {
                            Instantiate(PrefabFoundation, GetPosition(i, j), transform.rotation);
                        }
                        else
                        {
                            Instantiate(PrefabBuilding, GetPosition(i,j), transform.rotation);
                        }
                    }
                }
            }
            
        }
    }

    Vector3 GetPosition(int i, int j)
    {
        return new Vector3(j + OffsetGeneratorX, Height, i + OffsetGeneratorZ);
    }
}
