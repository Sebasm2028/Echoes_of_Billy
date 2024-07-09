using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // El transform del jugador a seguir
    public Vector3 offset; // La diferencia de posición entre la cámara y el jugador


    void LateUpdate()
    {
        // Actualiza la posición de la cámara para seguir al jugador
        transform.position = player.position + offset;

    }
}
