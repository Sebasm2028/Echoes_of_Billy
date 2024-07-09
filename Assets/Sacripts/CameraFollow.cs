using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // El transform del jugador a seguir
    public Vector3 offset; // La diferencia de posici�n entre la c�mara y el jugador


    void LateUpdate()
    {
        // Actualiza la posici�n de la c�mara para seguir al jugador
        transform.position = player.position + offset;

    }
}
