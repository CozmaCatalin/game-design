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
    public static int currentCoins = 50;
    public static ShopWeapon selectedWeapon;
    public static ShopMap selectedMap;
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
        currentCoinsText.text = "Current coins: " + currentCoins;
    }


    void PlayBtn()
    {
        SceneManager.LoadScene(sceneName: "Map1");
    }
}
