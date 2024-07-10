using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpV : MonoBehaviour
{

    public GameObject enemy;
    private EnemyController enemyController;

    private void Start()
    {
        enemyController = enemy.GetComponent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Si el poder colisiona con el jugador
        if (other.CompareTag("Player"))
        {
            enemyController.OnPowerValidationEnemy(3f);//Llama a la courutina para activar al jugador en 3 seg
            //Desactiva el poder
            gameObject.SetActive(false);
            PoolingManager.Instance.ReturnPowerUp(gameObject);
        }
    }
}
