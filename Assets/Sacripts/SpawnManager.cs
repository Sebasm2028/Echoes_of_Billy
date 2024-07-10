using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public List<GameObject> powerUp;
    public float spawnInterval = 5f;
    public Vector2 spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPowers());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnPowers()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnPower();
        }
    }

    private void SpawnPower()
    {
        int randomIndex = Random.Range(0, powerUp.Count);
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnRange.x, spawnRange.x),
            Random.Range(-spawnRange.y, spawnRange.y),
            0
        );

        Instantiate(powerUp[randomIndex], randomPosition, Quaternion.identity);
    }
}
