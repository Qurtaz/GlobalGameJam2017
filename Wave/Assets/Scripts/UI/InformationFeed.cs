﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationFeed : MonoBehaviour {

    public GameObject LifeText, ResistanceText, IncomeText, InfoText,
                      UpgradeButton, ReinforceButton, BuildButton, DestroyButton; 
    public Image MiniatureImage;
    public bool isBuildUpon;

    void Awake()
    {
        isBuildUpon = false;
    }

    void feedInfo(int life, int maxLife, float resistance, int income, string info, Image image, bool canUpgrade, bool canReinforce, bool canBuild, bool canDestroy)
    {
        LifeText.GetComponent<Text>().text = "Life: " + life.ToString() + "/" + maxLife.ToString();
        ResistanceText.GetComponent<Text>().text = "Resistance: " + (resistance*100).ToString() + "%";

        if (income>=0)
            IncomeText.GetComponent<Text>().text = "Income: " + income.ToString();
        else
            IncomeText.GetComponent<Text>().text = "Cost: " + income.ToString();

        InfoText.GetComponent<Text>().text = info;

        MiniatureImage = image;


    }
}
