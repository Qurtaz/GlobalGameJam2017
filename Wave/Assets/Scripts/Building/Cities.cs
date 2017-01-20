using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cities : Building {
    public float generateMoney;
    public bool upgrade;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void Work(GameObject Vawe)
    {
        Wave z = Vawe.GetComponent<Wave>();
        if (z != null)
        {
   //         z.GeneratObstacel(builgingLevel);
        }
    }
    public void AddMoney()
    {
        Player.money += generateMoney;
    }
    public override bool CanUpgrade()
    {
        return upgrade;
    }
}
