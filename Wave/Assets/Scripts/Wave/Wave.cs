using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {


    [Range(0, 40)]
    public float WaveResist = 10f;

    public static int DistanceLimit = 100;
    public static float MinimalHeight = 0.5f;

    public float Weight = 1;
    public float Lenght = 100;

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
        
    }

    int strength;
    public int Strength
    {
        get
        {
            return strength;
        }
        set
        {
            strength = value;
        }
    }

    public float height = 3;
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
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(Weight, height, Lenght), TimeToLerp);
        }
        else
        {
            
            transform.localScale = new Vector3(Weight, height, Lenght);
            CheckHeight();
        }
        

    }

    

    public void GeneratObstacel(int builgingLevel) //uderzyl w budynek
    {
        if (GetComponent<WaveMoving>().rewind)
        {
            return;
        }
        builgingLevel += 1;
        
        Height -= (builgingLevel/2) * (1f-(WaveResist+55)/100f);
    }

    public void GeneratObstacel(int builgingLevel, int addisionForse) //uderzyl w przeszkode
    {
        if (GetComponent<WaveMoving>().rewind)
        {
            return;
        }
        builgingLevel += 1;
        
        Height -= (builgingLevel*5 + addisionForse/2)/10 * (1f - (WaveResist + 55 )/ 100f);
    }

}
