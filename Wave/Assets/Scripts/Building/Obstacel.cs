using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacel : Building {
    protected int addisionForse;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    public override void Work(GameObject Vawe)
    {
        Wave z = Vawe.GetComponent<Wave>();
        if(z != null)
        {
             z.GeneratObstacel(builgingLevel, addisionForse);
        }
    }
}
