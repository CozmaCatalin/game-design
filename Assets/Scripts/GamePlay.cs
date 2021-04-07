using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnPositions;
    public GameObject[] enemyPrefabs;
    public Button MenuBackButton;
    public Transform bossSpawn;
    public GameObject boss;
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
    public bool bossSpawned;
    public bool losed = false;
    public bool roundDone = false;


    void Start()
    {
        currentMonsters = 0;
        wave = 0;
        maxWaves = 3;
        bossSpawned = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        MenuBackButton.onClick.AddListener(GoToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        GameManager();
        //if (roundDone)
        //{
        //    Debug.Log("ROundDONE!");
        //    MenuButton.SetBool("roundDone",true);
        //}
    }

    private void GoToMenu()
    {
        ShopManager.currentCoins += int.Parse(coins.text);
        SceneManager.LoadScene(sceneName: "Menu");

    }

    private void GameManager()
    {
        if (currentMonsters == 0 && wave < maxWaves)
        {
            waveAnimator.SetTrigger("fadeIn");
            wave += 1;
            waveNumber.text = "Wave " + wave;
            monsterToSpawnPerWave = Random.Range(5, 10) * wave;
            //monsterToSpawnPerWave = 1 * wave;
            //StartCoroutine(SpawnMonsters());
            SpawnMonsters();
        }
        if(currentMonsters == 0 && wave == maxWaves && bossSpawned == false)
        {
            bossSpawned = true;
            Instantiate(boss, bossSpawn.position, transform.rotation);
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

    private void SpawnMonsters()
    {
        while (monsterToSpawnPerWave > 0)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = 0 ;
            if(randEnemy == 1)
            {
                randSpawnPoint = Random.Range(0,2);
            } else
            {
                randSpawnPoint = Random.Range(2, spawnPositions.Length);
            }
            Instantiate(enemyPrefabs[randEnemy], spawnPositions[randSpawnPoint].position, transform.rotation);
            monsterToSpawnPerWave -= 1;
            currentMonsters += 1;
        }
    }
}
