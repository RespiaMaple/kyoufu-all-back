using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public GameObject[] airborneObstaclePrefabs;
    public GameObject[] groundObstaclePrefabs;
    public float maxSpeed = 10f;
    public float minSpeed = 8f;
    public float spawnInterval = 1.5f;  // 障礙物生成間隔
    public Transform airSpawnPoint;  // 空中生成位置
    public float speedIncreaseAmount = 2f; 
    public float speedIncreaseInterval = 30f;
    private int speedIncreaseTimes = 0; //提速次數

    private float spawnTimer = 0f;
    private float speedIncreaseTimer = 0f; //速度增加計時器

    private void Update()
    {
        // 更新生成計時器
        spawnTimer += Time.deltaTime;
        speedIncreaseTimer += Time.deltaTime;

        // 每隔一定時間生成一個障礙物
        if (spawnTimer >= spawnInterval)
        {
            SpawnObstacle();
            spawnTimer = 0f;
        }
        // 每隔一定時間增加速度
        if (speedIncreaseTimer >= speedIncreaseInterval && speedIncreaseTimes < 4)
        {
            IncreaseSpeed();
            speedIncreaseTimer = 0f;
            spawnInterval -= 0.1f;
            speedIncreaseTimes += 1;
        }
    }

    private void SpawnObstacle()
    {
        GameObject obstaclePrefab;
        GameObject obstacle;

        if (IsAirbornePosition())
        {
            // 在空中生成特定的障礙物
            int randomIndex = Random.Range(0, airborneObstaclePrefabs.Length);
            obstaclePrefab = airborneObstaclePrefabs[randomIndex];
            obstacle = Instantiate(obstaclePrefab, airSpawnPoint.position, Quaternion.identity);
        }
        else
        {
            // 在地面生成障礙物
            int randomIndex = Random.Range(0, groundObstaclePrefabs.Length);
            obstaclePrefab = groundObstaclePrefabs[randomIndex];
            obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        }

        // 設定障礙物的移動速度
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        Rigidbody2D obstacleRb = obstacle.GetComponent<Rigidbody2D>();
        obstacleRb.velocity = new Vector2(-randomSpeed, 0f);

    }

    private bool IsAirbornePosition()
    {
        return Random.value < 0.4f;
    }

    private void IncreaseSpeed()
    {
        minSpeed += speedIncreaseAmount;
        maxSpeed += speedIncreaseAmount;
    }    
}
