using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnPositions;
    public GameObject[] enemyPrefabs;
    public int positionsNumber = 4;
    public int wave = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.L))
        {
            Debug.Log("Enemy spawned!");
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPositions.Length);

            Instantiate(enemyPrefabs[0], spawnPositions[randSpawnPoint].position, transform.rotation);
        }
    }
}
