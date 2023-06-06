using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawn : MonoBehaviour
{
    public GameObject shieldPrefab;
    public float speed = 8f;
    public float minSpawnInterval = 10f;
    public float maxSpawnInterval = 15f;


    private void Start() 
    {
        Invoke("SpawnSheild", 10f);
    }

    private void SpawnSheild()
    {
        GameObject shield = Instantiate(shieldPrefab, transform.position, Quaternion.identity);

        Rigidbody2D shieldRb = shield.GetComponent<Rigidbody2D>();
        shieldRb.velocity = new Vector2(-speed, 0f);

        Invoke("SpawnShield", GetRandomSpawnInterval());
    }

    private float GetRandomSpawnInterval()
    {
        return Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}
