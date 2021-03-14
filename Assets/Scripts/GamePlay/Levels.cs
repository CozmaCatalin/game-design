using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    // Start is called before the first frame update
    private int maxLevels = 8;
    public int currentLevel;
    public int enemyesLeft;
    void Start()
    {
        currentLevel = 1;
        enemyesLeft = 2;
    }

    public void EnemyKilled()
    {
        enemyesLeft -= 1;
        if(enemyesLeft == 0)
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        currentLevel += 1;
        enemyesLeft = currentLevel * 10;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
