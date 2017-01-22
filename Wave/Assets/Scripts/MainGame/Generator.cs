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
    public GameObject Ghost;

    public int CountBuildingsT2 = 2;
    public int CountBuildingsT1 = 4;

    public int Height = 2;

    void Awake()
    {
        Randomize();
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
    public int TestCountCreatedRoad = 0;
    void Generate()
    {

        RoadInstantiate = new GameObject[width,length];
        int CountOfHouse = 0;
    
        for(int i = 0; i < length; i++)
        {
            if(i%2 == 0)
            {
                for (int j = 0; j < width; j++)
                {
                    RoadInstantiate[j, i] = Instantiate(PrefabRoad, GetPosition(i, j), transform.rotation);
                    TestCountCreatedRoad++;
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
                        RoadInstantiate[j, i] = Instantiate(PrefabRoad, GetPosition(i, j), transform.rotation);
                        TestCountCreatedRoad++;
                    }
                    else
                    {
                        if(j == Road)
                        {
                            
                            RoadInstantiate[j,i] = Instantiate(PrefabRoad, GetPosition(i, j), transform.rotation);
                            TestCountCreatedRoad++;



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
                            tmp.GetComponent<NormalBuilding>().SetLevelBuilding(UpgradesBulid[CountOfHouse]);
                            Instantiate(Ghost, GetPosition(i, j), transform.rotation);
                            CountOfHouse++;
                        }
                    }
                }
            }
            
        }
        SetRoad();
    }

    //0 I
    //1 -
    //2 +
    //3 (
    //4
    //5
    //6

    public int TestCountChangeRoad = 0;
    void SetRoad()
    {
        bool[] H = new bool[4];
        //  1
        //0   2
        //  3
        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                    if(RoadInstantiate[i,j] == null)
                    {
                        continue;
                    }
                    TestCountChangeRoad++;
                    H[0] = HaveRoad(i - 1, j);
                    H[1] = HaveRoad(i, j + 1);
                    H[2] = HaveRoad(i + 1, j);
                    H[3] = HaveRoad(i, j - 1);
                //Debug.Log("Sytuacja: " + H[0].ToString() + H[1].ToString() + H[2].ToString() + H[3].ToString());
                    if (H[0] && H[1] && H[2] && H[3])
                    {
                        RoadInstantiate[i, j].GetComponent<Road>().SetTypeRoad(2);

                    }
                    else
                    if (H[0] && H[1] && !H[2] && !H[3])
                    {
                        RoadInstantiate[i, j].GetComponent<Road>().SetTypeRoad(6);

                    }
                    else
                    if (!H[0] && H[1] && H[2] && !H[3])
                    {
                        RoadInstantiate[i, j].GetComponent<Road>().SetTypeRoad(5);

                    }
                    else
                    if (!H[0] && !H[1] && H[2] && H[3])
                    {
                        RoadInstantiate[i, j].GetComponent<Road>().SetTypeRoad(4);

                    }
                    else
                    if (H[0] && !H[1] && !H[2] && H[3])
                    {
                        RoadInstantiate[i, j].GetComponent<Road>().SetTypeRoad(3);

                    }
                    else
                    if (H[0] && !H[1] && H[2] && !H[3])
                    {
                        RoadInstantiate[i, j].GetComponent<Road>().SetTypeRoad(0);

                    }
                    else
                    if (!H[0] && H[1] && !H[2] && H[3])
                    {
                        RoadInstantiate[i, j].GetComponent<Road>().SetTypeRoad(1);

                    }
                    else
                    if (H[0] && H[1] && !H[2] && H[3])
                    {
                    RoadInstantiate[i, j].GetComponent<Road>().SetTypeRoad(10);

                    }
                else
                    if (H[0] && H[1] && !H[2] && !H[3])
                {
                    RoadInstantiate[i, j].GetComponent<Road>().SetTypeRoad(9);

                }
                else
                    if (!H[0] && H[1] && H[2] && H[3])
                {
                    RoadInstantiate[i, j].GetComponent<Road>().SetTypeRoad(8);

                }
                else
                    if (H[0] && !H[1] && H[2] && H[3])
                {
                    RoadInstantiate[i, j].GetComponent<Road>().SetTypeRoad(7);

                }

                else
                    {
                        RoadInstantiate[i, j].GetComponent<Road>().SetTypeRoad(2);
                    }
                    
                }
        }
    }

    bool HaveRoad(int _width, int _length)
    {
        if(_width < 0 || _width >= width)
        {
            return false;
        }
        if(_length < 0 || _length >= length)
        {
            return false;
        }

        if(RoadInstantiate[_width,_length] == null)
        {
            return false;
        }
        else
        {
            return true;
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
