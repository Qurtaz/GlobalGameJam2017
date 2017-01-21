using UnityEngine;
using UnityEngine.EventSystems;

public class MasterController : MonoBehaviour
{
    public GameObject cameraSupport;

    void Update()
    {
        if (Input.GetButtonDown("Cancel") == true)
            Application.Quit();
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
            //(hit.transform.gameObject)
        }
    }
}
