using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {


    [Range(0, 40)]
    public float WaveResist = 10f;

    public static int DistanceLimit = 10;
    public static float MinimalHeight = 0.5f;

    public float Weight = 5;
    public float Lenght = 1;

    public int StartSpeed;

    public void CheckHeight()
    {
        if (GetComponent<Wave>().height < MinimalHeight)
        {
            GetComponent<WaveMoving>().RewindWave();
        }
    }

    void Awake()
    {
        speed = StartSpeed;
    }

    void Start()
    {
        TimeToLerp = 0;
        Height = 3;
    }

    int strength;
    public int Strength
    {
        get
        {
            return strength;
        }
    }

    float height;
    public float Height 
    {
        get
        {
            return height;
        }
        set
        {
            
            TimeToLerp = 0;
            
            
            height = value;
            CheckHeight();
           // transform.localScale = new Vector3(Weight, height, Lenght);
        }
    }

    int speed;
    public int Speed
    {
        get
        {
            return speed;
        }
    }

    int score;
    public int Score
    {
        get
        {
            return score;
        }
    }

    float TimeToLerp;

    public float DroppingSpeed = 0.05f;
    public float ViewSpeedLerping = 0.5f;

    void Update()
    {

        if(Height < 0)
        {
            Destroy(this.gameObject);
        }
        height -= Time.deltaTime * DroppingSpeed;
        if (TimeToLerp < 1)
        {
            TimeToLerp += Time.deltaTime* ViewSpeedLerping;
        }
        else
        {
            
            transform.localScale = new Vector3(Weight, height, Lenght);
        }
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(Weight, height, Lenght), TimeToLerp);

    }

    

    public void GeneratObstacel(int builgingLevel) //uderzyl w budynek
    {
        if (WaveMoving.rewind)
        {
            return;
        }
        builgingLevel += 1;
        Debug.Log("dziala");
        Height -= builgingLevel * (1f-(WaveResist+55)/100f);
    }

    public void GeneratObstacel(int builgingLevel, int addisionForse) //uderzyl w przeszkode
    {
        if (WaveMoving.rewind)
        {
            return;
        }
        builgingLevel += 1;
        Debug.Log("dziala");
        Height -= (builgingLevel*5 + addisionForse/2)/10 * (1f - (WaveResist + 55 )/ 100f);
    }

}
