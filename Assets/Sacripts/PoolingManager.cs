using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager Instance;

    public GameObject powerUpPrefab;
    public int poolSize = 7;
    private List<GameObject> powerUpPool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitializePool();
    }

    private void InitializePool()
    {
        powerUpPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject powerUp = Instantiate(powerUpPrefab);
            powerUp.SetActive(false);
            powerUpPool.Add(powerUp);
        }
    }

    public GameObject GetPowerUp()
    {
        foreach (GameObject powerUp in powerUpPool)
        {
            if (!powerUp.activeInHierarchy)
            {
                return powerUp;
            }
        }
        return null;
    }

    public void ReturnPowerUp(GameObject powerUp)
    {
        powerUp.SetActive(false);
    }
}
