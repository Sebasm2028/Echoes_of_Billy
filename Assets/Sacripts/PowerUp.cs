using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float respawnTime = 10f; // Tiempo para que el power-up reaparezca
    public float enemyDisableTime = 7f; // Tiempo que el enemigo permanecerá desactivado

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Encuentra al enemigo y desactívalo temporalmente
            GameObject enemy = GameObject.FindWithTag("Enemy");
            if (enemy != null)
            {
                StartCoroutine(DisableEnemyTemporarily(enemy));
            }

            // Desactivar el power-up y reactivar después de un tiempo
            StartCoroutine(RespawnPowerUp());
        }
    }

    private IEnumerator DisableEnemyTemporarily(GameObject enemy)
    {
        enemy.SetActive(false);
        yield return new WaitForSeconds(enemyDisableTime);
        enemy.SetActive(true);
    }

    private IEnumerator RespawnPowerUp()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        gameObject.SetActive(true);
    }
}