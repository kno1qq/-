using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Show : MonoBehaviour
{
    public GameObject EnemyPrefab;    // 敵人的預置物
    public GameObject BossPrefab;     // Boss敵人的預置物
    public int initialSpawnCount = 5;  // 初始生成數量
    public int maxSpawnCount = 10;     // 最大生成數量
    public int bossSpawnDelay = 300;   // Boss生成延遲時間（秒）
    public float spawnRangeX = 8f;     // 生成範圍的 X 軸
    public float spawnRangeY = 8f;     // 生成範圍的 Y 軸
    public float spawnPositionZ = -2f; // 生成位置的 Z 軸
    public float spawnInterval = 30f;  // 生成間隔時間（秒）
    public float spawnIncreaseRate = 1f; // 生成數量增加率

    private int currentSpawnCount;     // 目前生成數量
    private bool isBossSpawned = false; // 判斷Boss是否已生成
    private float elapsedTime = 0f;    // 經過的時間

    private void Start()
    {
        currentSpawnCount = initialSpawnCount;
        GenerateEnemies();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        // Debug.Log(elapsedTime);
        if (!isBossSpawned && elapsedTime >= bossSpawnDelay)
        {
            SpawnBoss();
        }

        if (elapsedTime >= spawnInterval)
        {
            GenerateEnemies();
            spawnInterval += spawnInterval;
        }
    }

    private void GenerateEnemies()
    {
        for (int i = 0; i < currentSpawnCount; i++)
        {
            float x = Random.Range(-spawnRangeX, spawnRangeX);
            float y = Random.Range(-spawnRangeY, spawnRangeY);
            Vector3 spawnPosition = new Vector3(x, y, spawnPositionZ);

            Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void SpawnBoss()
    {
        float x = Random.Range(-spawnRangeX, spawnRangeX);
        float y = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 spawnPosition = new Vector3(x, y, spawnPositionZ);

        Instantiate(BossPrefab, spawnPosition, Quaternion.identity);

        isBossSpawned = true;
    }

    private void IncreaseSpawnCount()
    {
        if (currentSpawnCount < maxSpawnCount)
        {
            currentSpawnCount += Mathf.RoundToInt(currentSpawnCount * spawnIncreaseRate);
            GenerateEnemies();
        }
    }
}
