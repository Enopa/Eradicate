using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnPoints;
    
    private GameObject[] activeEnemies;
    [SerializeField]
    private GameObject[] enemyTypes;

    [SerializeField]
    private int maxEnemies;
    // Start is called before the first frame update
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (activeEnemies.Length <= maxEnemies)
        {
            List<GameObject> goodPoints = new List<GameObject>();
            GameObject player = GameObject.Find("Player");
            for (int i = 0; spawnPoints.Length - 1 >= i; i++)
            {
                if (Vector3.Distance(spawnPoints[i].transform.position, player.transform.position) >= 10)
                {
                    goodPoints.Add(spawnPoints[i]);
                }
            }

            if (goodPoints.Count <= 0)
            {
                spawnEnemy(spawnPoints[Random.Range(0, spawnPoints.Length - 1)].transform, enemyTypes[Random.Range(0, enemyTypes.Length - 1)]);
            }
            else
            {
                spawnEnemy(goodPoints[Random.Range(0, goodPoints.Count - 1)].transform, enemyTypes[Random.Range(0, enemyTypes.Length )]);
            }
        }
    }

    void spawnEnemy(Transform spawnPoint, GameObject enemyType)
    {
        Instantiate(enemyType, spawnPoint);
    }
}
