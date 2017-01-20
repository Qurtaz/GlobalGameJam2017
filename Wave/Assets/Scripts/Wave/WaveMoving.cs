using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMoving : MonoBehaviour
{

    public GameObject plane;
    public GameObject wave;

    public int speed = 10;
    public Vector2 Direct = new Vector2(0, 1);

    public int Limit = 100;
    bool rewind;

    void Start()
    {
        rewind = false;
        Vector2 start = new Vector2(this.transform.position.x, this.transform.position.y);

        if (Limit > Vector2.Distance(start, new Vector2(this.transform.position.x, this.transform.position.y)) && !rewind)
        {
            rewind = true;
        }

        if (rewind)
        {
            this.transform.Translate(Direct * -speed);
        }
        else
        {
            this.transform.Translate(Direct * speed);
        }

    }
}
