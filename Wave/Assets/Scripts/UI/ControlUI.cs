using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlUI : MonoBehaviour {

    public GameObject cell;
    public GameObject Viwe;
    public GameObject UpdateViwe;
    public GameObject BuildingView;
    public Button UpdateBuilding;
    public Button UpdateFortification;
    public void setBuilding(GameObject Prefab)
    {
        GameObject bu = Instantiate(Prefab, cell.transform.position, cell.transform.rotation);
    }
    public void Menage(GameObject set)
    {
        if(cell.GetComponent<Cell>().doesHaveBuilding)
        {
            UpdateViwe.SetActive(true);
            UpdateData();
        }
        else
        {
            BuildingView.SetActive(true);
        }
        Viwe.GetComponent<RectTransform>().anchoredPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }
    public void UpdateData()
    {
        if (cell.GetComponent<Cell>().currentObject.GetComponent<Building>().CanUpgradeBuinding() == false)
        {
            UpdateBuilding.interactable = false;
            UpdateBuilding.gameObject.GetComponentInChildren<Text>().text = "MAX";
        }
        else
        {
            UpdateBuilding.interactable = true;
            UpdateBuilding.gameObject.GetComponentInChildren<Text>().text = "Upgrade Building";
        }
        if (cell.GetComponent<Cell>().currentObject.GetComponent<Building>().CanUpgradeFortifiactiong() == false)
        {
            UpdateFortification.interactable = false;
            UpdateFortification.gameObject.GetComponentInChildren<Text>().text = "MAX";
        }
        else
        {
            UpdateFortification.interactable = true;
            UpdateFortification.gameObject.GetComponentInChildren<Text>().text = "Upgrade Fortification";
        }
    }
}
