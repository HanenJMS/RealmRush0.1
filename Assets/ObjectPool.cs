using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<GameObject> enemiesToSpawn = new List<GameObject>();
    [SerializeField] float spawnTimer = 1f;
    [SerializeField] int spawnCount = 5;
    GameObject[] enemies;
    private void Awake()
    {
        PopulatePool();
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    void PopulatePool()
    {
        enemies = new GameObject[spawnCount];
        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = Instantiate(enemiesToSpawn[0], transform);
            enemies[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnableEnemies();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void EnableEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            if(!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return;
            }
        }
    }
}
