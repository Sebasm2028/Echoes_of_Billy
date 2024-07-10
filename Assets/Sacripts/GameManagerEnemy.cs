using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEnemy : MonoBehaviour
{
    public static GameManagerEnemy Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateEnemyAfterDelay(GameObject enemy, float delay)
    {
        StartCoroutine(ActivationCoroutine(enemy, delay));
    }

    private IEnumerator ActivationCoroutine(GameObject enemy, float delay)
    {
        Debug.Log("Enemy deactivated");
        enemy.SetActive(false);
        yield return new WaitForSeconds(delay);
        Debug.Log("Enemy activated");
        enemy.SetActive(true);
    }
}
