using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {


    public static int DistanceLimit = 2;
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
        
        Height = 8;
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
            height = value/10;
            CheckHeight();
            transform.localScale = new Vector3(Weight, height, Lenght);
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

    public void GeneratObstacel(int builgingLevel) //uderzyl w budynek
    {

    }

    public void GeneratObstacel(int builgingLevel, int addisionForse) //uderzyl w przeszkode
    {

    }

}
