﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    const int PLAY_BTN = 0;

    private static ShopManager instance;
    public static ShopManager Instance { get { return instance; } }

    public static bool[] unlocked = new bool[5];
    public static bool[] unlockedMaps = new bool[2];
    public static int currentCoins = 1000;
    public static ShopWeapon selectedWeapon;
    public static ShopMap selectedMap;
    public static Text coins;
    public static float speed = 0.1f;
    public static float strength = 0.1f;
    public static float health = 0.1f;
    public static int speedPrice = 10;
    public static int strengthPrice = 10;
    public static int healthPrice = 10;

    public Text currentCoinsText;
    public Button[] buttons;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        buttons[PLAY_BTN].onClick.AddListener(PlayBtn);
        coins = currentCoinsText;
        currentCoinsText.text = "Current coins: " + currentCoins;
    }


    void PlayBtn()
    {
        if (selectedWeapon && selectedMap)
        {
            SceneManager.LoadScene(sceneName: selectedMap.MapName);
        }
    }

    public static void ModifyCoins(int value)
    {
        currentCoins -= value;
        coins.text = "Current coins: " + currentCoins;
    }
}
