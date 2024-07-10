using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner1 : MonoBehaviour
{
    public int powerUpCount = 7;
    public Vector3 spawnAreaMin;
    public Vector3 spawnAreaMax;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPowerUps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPowerUps()
    {
        for (int i = 0; i < powerUpCount; i++)
        {
            GameObject powerUp = PoolingManager.Instance.GetPowerUp();
            if (powerUp != null)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                    Random.Range(spawnAreaMin.z, spawnAreaMax.z)
                );

                powerUp.transform.position = randomPosition;
                powerUp.SetActive(true);
            }
        }
    }
}
