using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;

    public int difficulty;
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }

    private void Check()
    {
        ColorBlock colors = button.colors;

        if (ShopManager.gameDifficulty == difficulty)
        {
            colors.normalColor = Color.red;
        } else
        {
            colors.normalColor = Color.blue;
        }
        button.colors = colors;

    }

    private void TaskOnClick()
    {
        ShopManager.SetGameDifficulty(difficulty);
    }
}
