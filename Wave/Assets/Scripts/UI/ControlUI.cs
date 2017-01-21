using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUI : MonoBehaviour {

    public GameObject cell;

    public void setBuilding(GameObject Prefab)
    {
        Cell set = cell.GetComponent<Cell>();
        GameObject bu = Instantiate(Prefab, cell.transform.position, cell.transform.rotation);
        set.
    }
}
