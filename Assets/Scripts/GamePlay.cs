﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GamePlay : MonoBehaviour
{
    public int playerSpawnPoint = 4;
    // Start is called before the first frame update
    public Transform[] spawnPositions;
    public GameObject[] enemyPrefabs;
    public GameObject[] enterWaves;
    public GameObject[] walls;
    public Button MenuBackButton;
    public Transform bossSpawn;
    public GameObject boss;
    public GameObject playerPrefab;
    public Animator waveAnimator;
    public Animator MenuButton;
    private PlayerController player;
    public Text waveNumber;
    public Text coins;
    public bool isSpawning;
    public int wave = 0;
    public int maxWaves;
    public int monsterToSpawnPerWave = 10;
    public int currentMonsters;
    public int currentWall = -1;
    public bool bossSpawned;
    public bool losed = false;
    public bool roundDone = false;


    void Start()
    {
        currentMonsters = 0;
        wave = 0;
        maxWaves = 4;
        bossSpawned = false;
        isSpawning = false;
        playerSpawnPoint = 4;
        SpawnPlayer();
        currentWall = -1;
        MenuBackButton.onClick.AddListener(GoToMenu);
        EnterWave();
    }

    void Update()
    {
        GameManager();
        if (roundDone)
        {
            Debug.Log("ROundDONE!");
        }
    }

    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, spawnPositions[playerSpawnPoint].position, transform.rotation);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    private void GoToMenu()
    {
        ShopManager.currentCoins += int.Parse(coins.text);
        SceneManager.LoadScene(sceneName: "Menu");

    }

    private void GameManager()
    {
        if (currentMonsters == 0 && wave < maxWaves && isSpawning == false)
        {
            walls[currentWall].SetActive(false);
        }

        if(player.health <= 0 && player.heartsNumber <= 0 && losed == false)
        {
            waveNumber.color = Color.red;
            waveNumber.text = "You lose!";
            waveAnimator.SetTrigger("fadeIn");
            losed = true;
            roundDone = true;
        }


    }

    IEnumerator SpawnMonsters()
    {
        isSpawning = true;
        while (monsterToSpawnPerWave > 0)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            //int randSpawnPoint = 0 ;
            //if(randEnemy == 1)
            //{
            //    randSpawnPoint = Random.Range(0,2);
            //} else
            //{
            //    randSpawnPoint = Random.Range(2, spawnPositions.Length);
            //}
            yield return new WaitForSeconds(1f);
            Instantiate(enemyPrefabs[randEnemy], spawnPositions[wave-1].position, transform.rotation);
            monsterToSpawnPerWave -= 1;
            currentMonsters += 1;
        }
        isSpawning = false;
    }

    public void EnterWave()
    {
        if (currentWall >= 0)
        {
            enterWaves[currentWall].SetActive(false);
            spawnPositions[playerSpawnPoint].transform.position = enterWaves[currentWall].transform.position;
            walls[currentWall].SetActive(true);
        }

        
            Debug.Log("Enter wabe from gameplat!");
            waveAnimator.SetTrigger("fadeIn");
            wave += 1;
            currentWall += 1;
            waveNumber.text = "Wave " + wave;
            monsterToSpawnPerWave = Random.Range(1, 2) * wave;
            StartCoroutine(SpawnMonsters());
        

        if(wave == maxWaves && bossSpawned == false)
        {
            bossSpawned = true;
            Instantiate(boss, bossSpawn.position, transform.rotation);
        }
    }
}
