using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    // Start is called before the first frame update

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

    public void ActivateEnemyAfterDelay(GameObject enemy, float delay)
    {
        StartCoroutine(ActivationCoroutine(enemy, delay));
    }

    private IEnumerator ActivationCoroutine(GameObject enemy, float delay)
    {
        enemy.SetActive(false);
        yield return new WaitForSeconds(delay);
        enemy.SetActive(true);
    }
}
