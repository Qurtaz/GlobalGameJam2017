using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public int length = 10;
    public int width = 100;

    public int OffsetGeneratorX = 0;
    public int OffsetGeneratorZ = 0;

    public GameObject PrefabRoad;
    public GameObject PrefabBuilding;
    public GameObject PrefabFoundation;

    public int CountBuildingsT2 = 2;
    public int CountBuildingsT1 = 4;

    public int Height = 2;

    void Start()
    {
        //Randomize();
        Generate();
    }

    int[] UpgradesBulid;
    void Randomize()
    {
        UpgradesBulid = new int[(width - 4) * length / 2];
        for (int i = 0; i < UpgradesBulid.Length; i++)
        {
            UpgradesBulid[i] = 0;
        }

        int ActualPosition = 0;
        while(ActualPosition < CountBuildingsT2)
        {
            UpgradesBulid[ActualPosition] = 2;
            ActualPosition++;
        }
        while (ActualPosition < CountBuildingsT2 + CountBuildingsT1)
        {
            UpgradesBulid[ActualPosition] = 1;
            ActualPosition++;
        }


        int n = UpgradesBulid.Length;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0,n + 1);
            int value = UpgradesBulid[k];
            UpgradesBulid[k] = UpgradesBulid[n];
            UpgradesBulid[n] = value;
        }

        
    }
    GameObject[,] RoadInstantiate;
    void Generate()
    {

        RoadInstantiate = new GameObject[width,length];
        for(int i = 0; i< width; i++)
        {
            for(int j = 0; j < length; j++)
            {
                RoadInstantiate[i, j] = null;
            }
        }
    
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
                int Road = Random.Range(2, width - 2);
                int Foundation = Random.Range(1, width - 1);
                if(Foundation == Road)
                {
                    Foundation++;
                }
                for (int j = 0; j < width; j++) //width
                {
                    if (j == 0 || j == width - 1)
                    {
                        Instantiate(PrefabRoad, GetPosition(i, j), transform.rotation);
                    }
                    else
                    {
                        if(j == Road)
                        {
                            
                            RoadInstantiate[j,i] = Instantiate(PrefabRoad, GetPosition(i, j), transform.rotation);
                            


                        }
                        else if (Foundation == j)
                        {
                            Instantiate(PrefabFoundation, GetPosition(i, j), transform.rotation);
                        }
                        else
                        {
                            //Instantiate(PrefabBuilding, GetPosition(i, j, -0.5f), transform.rotation);
                            GameObject tmp;
                            tmp = Instantiate(PrefabBuilding, GetPosition(i,j, -0.5f), transform.rotation) as GameObject;
                            tmp.GetComponent<NormalBuilding>().SetLevelBuilding(0);
                           // CountOfHouse++;
                        }
                    }
                }
            }
            
        }
        SetRoad();
    }

    void SetRoad()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                RoadInstantiate[i, j] = null;
            }
        }
    }

    Vector3 GetPosition(int i, int j)
    {
        return new Vector3(j + OffsetGeneratorX, Height, i + OffsetGeneratorZ);
    }

    Vector3 GetPosition(int i, int j, float HeightModyfiaction)
    {
        return new Vector3(j + OffsetGeneratorX, Height + HeightModyfiaction, i + OffsetGeneratorZ);
    }

    
}
