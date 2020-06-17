using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    public float impulseMultiplier = 5f;
    
    private Rigidbody myRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 direction = new Vector3(0f, 1f, 0f);
            myRigidbody.AddForce(direction * impulseMultiplier, ForceMode.Impulse);
        }
    }
}
