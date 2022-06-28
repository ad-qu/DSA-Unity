using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    string informationFromAndroid;

    public static GameManager instance = null;

    public static BoardManager boardScript;

    public static int level = 0;

    AndroidJavaClass UnityPlayer;
    AndroidJavaObject currentActivity;

    void Start()
    {
        UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaObject intent = currentActivity.Call<AndroidJavaObject>("getIntent");
        bool hasExtra = intent.Call<bool>("hasExtra", "arguments");

        if (hasExtra)
        {
            AndroidJavaObject extras = intent.Call<AndroidJavaObject>("getExtras");
            informationFromAndroid = extras.Call<string>("getString", "arguments");

            string[] info = informationFromAndroid.Split("/");

            CoinSystem.coin = Convert.ToInt32(info[0]);

            if (info[1] == "true") { PlayerShoot.weapon1 = true; } else { PlayerShoot.weapon1 = false; }

            if (info[2] == "true") { PlayerShoot.weapon2 = true; } else { PlayerShoot.weapon2 = false; }

            if (info[3] == "true") { PlayerCollision.activeShield = true; } else { PlayerCollision.activeShield = false; }
        }
    }

    void Awake()
    {
        if (instance == null) { instance = this; }

        else if (instance != this) { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);

        boardScript = GetComponent<BoardManager>();
        
        InitGame();
    }

    static public void InitGame()
    {
        boardScript.SetupScene(level);
    }
}