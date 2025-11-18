using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // Prefab del enemigo
    public float spawnInterval = 2f;    // Tiempo entre spawns
    public float xMin = -8f;            // Limite izquierda
    public float xMax = 8f;             // Limite derecha
    public float spawnY = 4f;           // Altura de spawn 4 es la perfecta

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        float randomX = UnityEngine.Random.Range(xMin, xMax);
        Vector3 spawnPos = new Vector3(randomX, spawnY, 0f);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
