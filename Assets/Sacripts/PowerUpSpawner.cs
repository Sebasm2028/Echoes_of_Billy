using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public int numberOfPowerUps = 5;
    public Vector3 spawnAreaMin;
    public Vector3 spawnAreaMax;

    private List<GameObject> powerUps;

    void Start()
    {
        powerUps = new List<GameObject>();

        for (int i = 0; i < numberOfPowerUps; i++)
        {
            SpawnPowerUp();
        }
    }

    void SpawnPowerUp()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        GameObject newPowerUp = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
        powerUps.Add(newPowerUp);
    }
}