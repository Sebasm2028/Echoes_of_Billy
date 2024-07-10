using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f; // Velocidad del enemigo
    private Rigidbody enemyRB;
    private GameObject player;
    private Animator animator;
    public bool isEnemyOff = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player"); // Usar la etiqueta para encontrar al jugador
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Calcula la direcci�n hacia el jugador
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;

            // Mantener la altura del enemigo
            lookDirection.y = 0;

            // Mover el enemigo hacia el jugador
            enemyRB.MovePosition(transform.position + lookDirection * speed * Time.deltaTime);

            // Girar el enemigo para que mire al jugador
            Quaternion toRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);

            // Control de animaciones
            float moveSpeed = lookDirection.magnitude * speed;
            animator.SetFloat("Speed", moveSpeed);
        }
        else
        {
            // Si el jugador no est� presente, detener las animaciones
            animator.SetFloat("Speed", 0f);
        }

    }

    public void OnPowerValidationEnemy(float delay)
    {
        GameManager.Instance.ActivateEnemyAfterDelay(gameObject, delay);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.LoseLive();
        }
    }
}
