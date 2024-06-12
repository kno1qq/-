using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralShow : MonoBehaviour
{
    public GameObject mineralPrefab;    // 礦物的預置物
    public int minSpawnCount = 5;       // 最小生成數量
    public int maxSpawnCount = 10;      // 最大生成數量
    public float spawnRangeX = 8f;     // 生成範圍的 X 軸
    public float spawnRangeY = 8f;     // 生成範圍的 Y 軸
    public float spawnPositionZ=-2f;

    private void Start()
    {
        GenerateMinerals();
    }

    private void GenerateMinerals()
    {
        int spawnCount = Random.Range(minSpawnCount, maxSpawnCount + 1);

        for (int i = 0; i < spawnCount; i++)
        {
            float x = Random.Range(-spawnRangeX, spawnRangeX);
            float y = Random.Range(-spawnRangeY, spawnRangeY);
            Vector3 spawnPosition = new Vector3(x, y,spawnPositionZ);

            Instantiate(mineralPrefab, spawnPosition, Quaternion.identity);
        }
    }

}
