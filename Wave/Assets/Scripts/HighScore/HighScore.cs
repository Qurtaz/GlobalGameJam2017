using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour {

    const string privateCode = "T_QgWbagWkWpdaRi09dBVgJavH-TLEIk2wNezBo3y0Tg";
    const string publicCode = "586fde84b6dd1500a4c45bda";
    const string webURL = "http://dreamlo.com/lb/";

    public GameObject HighscoreList;
    public static string ScoreList;
    public static string ScorePlayer;


    public delegate void HighScoreAction();
    public static event HighScoreAction EndDataDownload;

    bool UploadingScore = false;

    void Awake()
    {
        

       
    }

    private void Start()
    {
        ScorePlayer = string.Empty;
        ScoreList = string.Empty;
        StartCoroutine(DownloadData());
       
    }

    public void AddNewHighscore(float Time)
    {

        StartCoroutine(UploadNewHighscore(PlayerData.Nick, CodeHighscore(Time)));
        
    }

    

    IEnumerator UploadNewHighscore(string username, int score)
    {
        UploadingScore = true;
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;
        UploadingScore = false;
        if (string.IsNullOrEmpty(www.error))
            print("Upload Successful");
        else
        {
            print("Error uploading: " + www.error);
        }
        
    }

    public static int CodeHighscore(float value)
    {
        return 1000000 - (int)Mathf.Round(value * 100);
    }

    public  static float UncodeHighscore(int value)
    {
        return (1000000 - value) / 100f;
    }

    public void RefreshData()
    {
        StartCoroutine(DownloadData());
    }

    IEnumerator DownloadData()
    {
        while (UploadingScore)
        {
            yield return new WaitForSeconds(0.1f);
        }
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;
        WWW www2 = new WWW(webURL + publicCode + "/pipe-get/" + PlayerData.Nick);
        yield return www2;

        if (!string.IsNullOrEmpty(www.error) && !string.IsNullOrEmpty(www2.error))
        {

            print("Error Downloading: " + www.error + " Player: " + www2.error);
            
        }
        else
        {
            ScorePlayer = www2.text;
            ScoreList = www.text;
            EndDataDownload();
        }
        



    }

    



}

