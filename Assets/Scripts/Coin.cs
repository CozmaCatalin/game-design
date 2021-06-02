using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    public int value;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "Map1")
        {
            value = 1 + ShopManager.gameDifficulty/3;
        }

        if(sceneName == "Map3")
        {
            value = 2 + ShopManager.gameDifficulty/3;
        }
        if(sceneName == "Map4")
        {
            value = 3 + ShopManager.gameDifficulty/3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
    }
}
