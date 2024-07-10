using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public HeartController heartPanel;
    public GameObject gameOverPanel; // Referencia al panel de Game Over
   // public int TotalPoints { get; private set; }
    //public GameObject enemyPrefab;

    private int numberHeart = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Another instance of GameManager already exists.");
            Destroy(gameObject);
        }
    }

    public void LoseLive()
    {
        numberHeart -= 1;

        if (numberHeart <= 0)
        {
            GameOver();
        }
        else
        {
            heartPanel.DisableHeart(numberHeart);
        }
    }

    public void Recover()
    {
        numberHeart += 1;
        heartPanel.ActiveHeart(numberHeart);
    }

    private void GameOver()
    {
         gameOverPanel.SetActive(true); // Muestra el panel de Game Over
        Time.timeScale = 0f; // Pausa el juego
        //AudioManager.Instance.StopAllSound(); // Detiene toda la música de fondo
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reanuda el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia el nivel actual
    }
}

/*
public void StartRespawnEnemyCoroutine(float respawnTime)
    {
        StartCoroutine(RespawnEnemy(respawnTime));
    }

    private IEnumerator RespawnEnemy(float respawnTime)
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(respawnTime);

        // Genera un nuevo enemigo en una posición aleatoria
        Vector3 randomPosition = new Vector3(
            Random.Range(-10f, 10f),
            0,
            Random.Range(-10f, 10f)
        );
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    } */

    /*
    public void AddPoints(int points)
    {
        TotalPoints += points;
        heartPanel.UpdatePoints(TotalPoints);
    }
    */