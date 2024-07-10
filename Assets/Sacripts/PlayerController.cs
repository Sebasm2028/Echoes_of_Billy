using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0F;
    public float turnSpeed = 5f;
    private Animator animator;
    private bool isGameStarted = false; // Nueva variable

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted) return; // Si el juego no ha empezado, no hacer nada

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //desactivar la tecla hacia abajo
        if (moveVertical < 0)
        {
            moveVertical = 0;
        }

        // Calcula el movimiento hacia adelante y atrás
        Vector3 movement = transform.forward * moveVertical * moveSpeed * Time.deltaTime;

        // Aplica el movimiento al Transform
        transform.position += movement;

        // Rotar al jugador
        float turn = moveHorizontal * turnSpeed * Time.deltaTime;
        transform.Rotate(0, turn, 0);

        // Actualiza el parámetro Speed del Animator
        animator.SetFloat("Speed", Mathf.Abs(moveVertical));
    }

    public void StartGame()
    {
        isGameStarted = true; // Método para iniciar el juego
    }
}

