using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    public float spawnInterval;
    public float spawnXRange;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);       
    }

    void SpawnEnemy()
    {
        if (GameManager.instance.isGameOver) return;
        
        float randomX = Random.Range(-spawnXRange, spawnXRange);
        Vector2 spawnPosition = new Vector2(randomX, 9f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
