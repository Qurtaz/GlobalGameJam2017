using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowHighScore : MonoBehaviour {

    const string privateCode = "T_QgWbagWkWpdaRi09dBVgJavH-TLEIk2wNezBo3y0Tg";
    const string publicCode = "586fde84b6dd1500a4c45bda";
    const string webURL = "http://dreamlo.com/lb/";

    public GameObject System;

    public Text LeftColumn;
    public Text RightColumn;

    public GameObject ButtonNextSite;
    public GameObject ButtonPreviousSite;

    

    private void OnEnable()
    {
        ActualSite = 0;
        HighScore.EndDataDownload += Refresh;
    }

    public int ActualSite;
    bool LastSite = false;

    public void Refresh()
    {
        string[] splited = HighScore.ScoreList.Split(new char[] { '|','\n' });
        LastSite = false;
        string forLeft = "";
        string forRight = "";
        const int JUMP = 6;
        const int COUNT_SCORE_PER_SITE = 20;
        for (int i = ActualSite * COUNT_SCORE_PER_SITE; i < (ActualSite+1)* COUNT_SCORE_PER_SITE ; i++)
        {
            if(i >= splited.Length / JUMP)
            {
                LastSite = true;
                
                break;
            }
            forLeft += (i + 1).ToString() + "." + splited[i* JUMP]  + "\n";
            float ToGetMinutes = HighScore.UncodeHighscore(int.Parse(splited[i * JUMP + 1]));
            int minutes = (int)ToGetMinutes / 60;
            ToGetMinutes -= (minutes * 60);
            forRight += minutes.ToString() + "." + ToGetMinutes.ToString() + "\n";
            
        }
        
        LeftColumn.text = forLeft;
        RightColumn.text = forRight;
        if(LastSite == true)
        {
            ButtonNextSite.SetActive(false);
        }
        else
        {
            ButtonNextSite.SetActive(true);
        }
        if(ActualSite == 0)
        {
            ButtonPreviousSite.SetActive(false);
        }
        else
        {
            ButtonPreviousSite.SetActive(true);
        }
        HighScore.EndDataDownload -= Refresh;
    }
    public void ChangeSite(int which)
    {
        if(HighScore.ScoreList == string.Empty)
        {
            return;
        }
        ActualSite = which;
        Refresh();

    }

    public void SetNextSite()
    {
        ChangeSite(ActualSite + 1);

    }

    public void SetPreviousSite()
    {
        if(ActualSite == 0)
        {
            return;
        }
        ChangeSite(ActualSite - 1);

    }
    

    void Update () {
		
	}
}
