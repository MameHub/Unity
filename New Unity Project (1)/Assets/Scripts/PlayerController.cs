using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 movementDirection = Vector3.zero;
        movementDirection.x = Input.GetAxis("Horizontal");
        movementDirection.z = Input.GetAxis("Vertical");
        movementDirection.Normalize();
        if (movementDirection.magnitude > 0)
        {
            rb.AddForce(movementDirection * speed, ForceMode.Force);
        }
        else
        {
            Vector3 velocity = rb.velocity;
            rb.AddForce(-velocity, ForceMode.Force);
        }
    }
}
