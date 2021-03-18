using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemyToSpawn;
    private int maxLevels = 4;
    public int currentLevel = 0;
    public int enemyesLeft = 0;
    public int multiplyValueEnemies = 10;
    public int enemyesToSpawn = 0;
    public Text levelText;
    public InventoryController inventoryController;

    void Start()
    {
        NextLevel();
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
        if(currentLevel != maxLevels)
        {
            currentLevel += 1;
            levelText.text = "Level " + currentLevel;
            enemyesLeft = currentLevel * multiplyValueEnemies;
            enemyesToSpawn = currentLevel * multiplyValueEnemies;
            inventoryController.EquipWeapon(currentLevel);
            StartCoroutine(EnemyDrop());
        }
    }

    private IEnumerator EnemyDrop()
    {
        while(enemyesToSpawn > 0)
        {
            int xPos = Random.Range(20, 40);
            int zPos = Random.Range(25, 50);
            Instantiate(EnemyToSpawn, new Vector3(xPos, 5, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
            enemyesToSpawn -= 1;

        }
    }
    // Update is called once per frame
 
}
