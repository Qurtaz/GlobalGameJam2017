using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    bool isBuiltOn;
    public GameObject currentObject;

    [SerializeField]
    Cell[] neighbors;

    void Start()
    {

    }

    public bool doesHaveBuilding
    {
        get
        {
            return isBuiltOn;
        }
    }

    public void BuildState(bool state)
    {
            isBuiltOn = state;
    }

    public Cell GetNeighbor(CellDirection direction)
    {
        return neighbors[(int)direction];
    }
}
