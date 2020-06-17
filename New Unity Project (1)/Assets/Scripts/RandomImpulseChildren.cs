using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomImpulseChildren : MonoBehaviour
{
    private Rigidbody[] rigidbodies;

    private void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            int randomIndex = Random.Range(0, rigidbodies.Length);
            rigidbodies[randomIndex].AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }
}
