using UnityEngine;
using UnityEngine.EventSystems;

public class MasterController : MonoBehaviour
{

    public CellGrid cellGrid;
    public ControlUI control;
    Cell previousCell;

    void Update()
    {
        if (Input.GetMouseButton(0) &&
            !EventSystem.current.IsPointerOverGameObject())
        {
            HandleInput();
        }
        else {
            previousCell = null;
        }
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            EditCell(cellGrid.GetCell(hit.point));
        }
    }

    void EditCell(Cell cell)
    {
        if (cell)
        {
           Debug.Log(cell.doesHaveBuilding);
            control.Menage(cell.gameObject);
        }
    }
}
