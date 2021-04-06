using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnPositions;
    public GameObject[] enemyPrefabs;
    public Transform bossSpawn;
    public GameObject boss;
    public Animator waveAnimator;
    public Text waveNumber;
    public bool isSpawning;
    public int wave = 0;
    public int maxWaves;
    public int monsterToSpawnPerWave = 10;
    public int currentMonsters;
    public bool bossSpawned;


    void Start()
    {
        currentMonsters = 0;
        wave = 0;
        maxWaves = 1;
        bossSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager();
    }

    private void GameManager()
    {
        if (currentMonsters == 0 && wave < maxWaves)
        {
            waveAnimator.SetTrigger("fadeIn");
            wave += 1;
            waveNumber.text = "Wave " + wave;
            //monsterToSpawnPerWave = Random.Range(5, 10) * wave;
            monsterToSpawnPerWave = 1 * wave;
            //StartCoroutine(SpawnMonsters());
            SpawnMonsters();
        }
        if(currentMonsters == 0 && wave == maxWaves && bossSpawned == false)
        {
            bossSpawned = true;
            Instantiate(boss, bossSpawn.position, transform.rotation);
        }
    }

    //IEnumerator SpawnMonsters()
    //{
    //    while (monsterToSpawnPerWave > 0)
    //    {
    //        int randEnemy = Random.Range(0, enemyPrefabs.Length);
    //        int randSpawnPoint = Random.Range(0, spawnPositions.Length);

    //        Instantiate(enemyPrefabs[0], spawnPositions[randSpawnPoint].position, transform.rotation);
    //        yield return new WaitForSeconds(2f);
    //        monsterToSpawnPerWave -= 1;
    //        currentMonsters += 1;
    //    }
    //}

    private void SpawnMonsters()
    {
        while (monsterToSpawnPerWave > 0)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPositions.Length);

            Instantiate(enemyPrefabs[0], spawnPositions[randSpawnPoint].position, transform.rotation);
            monsterToSpawnPerWave -= 1;
            currentMonsters += 1;
        }
    }
}
