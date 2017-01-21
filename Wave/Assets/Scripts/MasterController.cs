using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MasterController : MonoBehaviour
{
    public GameObject cameraSupport;
    public ControlUI control;

    public GameObject Info, Building, Trap, Menu;

    void Update()
    {
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

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            control.Menage(hit.transform.gameObject);
        }
    }

    void PauseGame(bool state)
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
