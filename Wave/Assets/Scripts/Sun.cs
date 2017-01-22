using UnityEngine;
using System.Collections;
[System.Serializable]
public class Light
{
    public GameObject west;
    public GameObject east;
    public GameObject north;
    public GameObject south;
}

public class Sun : MonoBehaviour {

    public GameObject target;

    public Light down;
    public Light up;
    public float speed = 1;


	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        target.gameObject.transform.Rotate(Time.deltaTime*speed, 0, 0);
    }
}
