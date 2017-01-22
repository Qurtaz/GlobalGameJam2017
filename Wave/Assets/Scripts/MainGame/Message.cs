using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {

    public static Text TextMessage;
    public Text nsTextMessage;

    void Start()
    {
        TextMessage = nsTextMessage;
    }

    public static void Set(string txt)
    {
        waiting = 5;
        TextMessage.text = txt;
    }
    static float waiting = 0;
	
	void Update () {
		if(waiting > 0)
        {
            waiting -= Time.deltaTime;
        }
        else
        {
            TextMessage.text = " ";
        }
	}
}
