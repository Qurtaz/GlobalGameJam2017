using UnityEngine;

public class PanelController : MonoBehaviour {

    public GameObject[] Panels;

    public void setMode(int mode) 
    {
        Refresh();
        Panels[mode].SetActive(true); 
    }

    public void Refresh()
    {
        foreach (GameObject panel in Panels)
        {
            panel.SetActive(false);
        }
    }
}
