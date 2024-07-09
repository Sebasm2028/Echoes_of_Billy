using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0F;
    private Rigidbody playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

    
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Aplica el movimiento al Rigidbody
        playerRigidBody.velocity = movement * moveSpeed;
    }
}
