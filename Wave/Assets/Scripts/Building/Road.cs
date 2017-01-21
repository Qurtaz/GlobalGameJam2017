using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {

    public GameObject[] Roads;

	public void SetTypeRoad(int a)
    {
        for(int i = 0; i < Roads.Length; i++)
        {
            Roads[a].SetActive(false);
        }
        Roads[a].SetActive(true);
    }
}
