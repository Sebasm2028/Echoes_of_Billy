using UnityEngine;
using Cinemachine;

public class CameraSetup : MonoBehaviour
{
    public string playerTag = "Player";
    private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        // Encuentra el jugador por su etiqueta
        GameObject player = GameObject.FindWithTag(playerTag);

        if (player != null)
        {
            // Configura la c�mara virtual de Cinemachine para seguir y mirar al jugador
            virtualCamera = GetComponent<CinemachineVirtualCamera>();

            if (virtualCamera != null)
            {
                virtualCamera.Follow = player.transform;
                virtualCamera.LookAt = player.transform;

                // A�adir y configurar el CinemachineCollider
                var collider = virtualCamera.gameObject.AddComponent<CinemachineCollider>();
                collider.m_AvoidObstacles = true;
                collider.m_Damping = 0.5f;
                collider.m_Strategy = CinemachineCollider.ResolutionStrategy.PullCameraForward;
                collider.m_CollideAgainst = LayerMask.GetMask("Default", "Obstacles"); // Ajusta las capas seg�n tus necesidades
            }
            else
            {
                Debug.LogError("No se encontr� un componente CinemachineVirtualCamera en el objeto.");
            }
        }
        else
        {
            Debug.LogError("No se encontr� un objeto con la etiqueta " + playerTag);
        }
    }
}