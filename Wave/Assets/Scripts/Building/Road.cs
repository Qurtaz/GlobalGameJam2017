using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {

    public GameObject[] Roads;

	public void SetTypeRoad(int a)
    {
        for(int i = 0; i < Roads.Length; i++)
        {
            Roads[i].SetActive(false);
        }
        Debug.Log("Wlaczylem " + a);
        Roads[a].SetActive(true);
    }
}
