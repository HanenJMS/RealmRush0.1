using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<GameObject> enemiesToSpawn = new List<GameObject>();
    [SerializeField] float spawnTimer = 1f;
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            foreach(GameObject enemy in enemiesToSpawn)
            {
                Instantiate(enemy, transform);
            }
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
