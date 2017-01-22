using UnityEngine;
using UnityEngine.UI;
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

            if (tagToBuild != string.Empty)
            {
                 if (hit.transform.tag != tagToBuild)
                 {
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
                Info.GetComponent<InformationFeed>().feedInfo(b.GetHP(), b.GetMaxHP(), b.GetStatima(), b.Income(), b.GetDesription(), b.GetImage(), b.CanUpgradeBuinding(), b.CanUpgradeFortifiactiong(), true);
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
