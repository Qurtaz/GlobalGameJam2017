using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class MasterController : MonoBehaviour
{
    public GameObject cameraSupport;
    public ControlUI control;

    public GameObject Menu, Info;
    public GameObject resource;

    Transform swivel, stick;
    float zoom = 1f;
    public float stickMinZoom, stickMaxZoom;

    public GameObject toBuild;
    public int typeOfBuilding;
    public int buildingCost;

    public GameObject Show;

    void Awake()
    {
        swivel = transform.GetChild(0);
        stick = swivel.GetChild(0);
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            float zoomDelta = -Input.GetAxis("Mouse ScrollWheel");
            if (zoomDelta != 0f)
            {
                AdjustZoom(zoomDelta);
            }
        }

        if (Input.GetButtonDown("Cancel") == true)
        {
            if (Menu.activeSelf == true)
            {
                Menu.SetActive(false);
                PauseGame(false);
            }
            else
            {
                Menu.SetActive(true);
                PauseGame(true);
            }
        }
        else if
            (Input.GetButtonDown("CamRotation") == true)
        {
            Vector3 Angle = cameraSupport.transform.eulerAngles;

            if (Input.GetAxis("CamRotation") > 0)
            {
                transform.rotation = Quaternion.Euler(Angle.x, Angle.y + 90, Angle.z);
            }
            else if (Input.GetAxis("CamRotation") < 0)
            {
                transform.rotation = Quaternion.Euler(Angle.x, Angle.y - 90, Angle.z);
            }
        }

        if (Input.GetMouseButton(0) &&
            !EventSystem.current.IsPointerOverGameObject())
        {
            HandleInput();
        }
    }

    void AdjustZoom(float delta)
    {
        zoom = Mathf.Clamp01(zoom + delta);

        float distance = Mathf.Lerp(stickMinZoom, stickMaxZoom, zoom);
        stick.localPosition = new Vector3(0f, 0f, distance);
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            string tagToBuild;
            switch (typeOfBuilding)
            {
                case 1: tagToBuild = "WaterTile";
                    break;
                case 2: tagToBuild = "BeachTile";
                    break;
                case 3:
                    tagToBuild = "LandTile";
                    break;
                case 4:
                    tagToBuild = "SpecialTile";
                    break;
                default: tagToBuild = string.Empty;
                    break;
            }
            Debug.Log(tagToBuild + " " + hit.transform.tag);
            if (tagToBuild != string.Empty)
            {
                 

                 if (hit.transform.tag != tagToBuild)
                 {
                        Show.GetComponent<ShowPlace>().SwitchOffAll();
                        toBuild = null;
                     typeOfBuilding = 0;
                     buildingCost = 0;
                     return;
                 }
                else
                {
                    if(Resources.Money >= buildingCost)
                    {
                        NormalBuilding tmp = null;
                        GameObject tmp2;
                        tmp2 = Instantiate(toBuild, hit.transform.gameObject.transform.position, transform.rotation);
                        tmp = tmp2.GetComponent<NormalBuilding>();

                        if(tmp != null)
                        {
                            StartCoroutine("Delay", tmp);
                        }
                        Resources.ChangeMoney(-buildingCost);
                    }

                    Show.GetComponent<ShowPlace>().SwitchOffAll();
                    toBuild = null;
                    typeOfBuilding = 0;
                    buildingCost = 0;
                    return;
                }
            }

            if (hit.transform.tag == "Bulding")
            {
                Info.SetActive(true);
                //resource.GetComponent<Resources>().CalculateHealth();
                Building b = hit.transform.gameObject.GetComponent<Building>();
                Info.GetComponent<InformationFeed>().feedInfo(b.GetHP(), b.GetMaxHP(), b.Income(), b.GetDesription(), b.GetImage(), b.CanUpgradeBuinding(), b.CanUpgradeFortifiactiong(), true);
                //control.Menage(hit.transform.gameObject);

            }
            else
            {
                Info.SetActive(false);
            }
        }
        else
        {
            Info.SetActive(false);
        }
    }


    IEnumerator Delay(NormalBuilding no)
    {
        Debug.Log("DODODDO");
        yield return new WaitForSeconds(0.1f);
        no.SetLevelBuilding(0);
    }

    public void PauseGame(bool state)
    {
        if (state == true)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
