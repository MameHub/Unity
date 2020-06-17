using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CubeMoveColor : MonoBehaviour
{
    [SerializeField]
    private float impulseForce = 5f;
    [SerializeField]
    private Material redMaterial;
    [SerializeField]
    private Material greenMaterial;

    private Rigidbody myRigidbody;
    private MeshRenderer meshRenderer;

    private bool isUsingGreenMaterial;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        isUsingGreenMaterial = false;
        meshRenderer.material = redMaterial;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            AddImpulse(Vector3.up);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            AddImpulse(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            AddImpulse(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            AddImpulse(Vector3.right);
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(isUsingGreenMaterial)
            {
                isUsingGreenMaterial = false;
                meshRenderer.material = redMaterial;
            }
            else
            {
                isUsingGreenMaterial = true;
                meshRenderer.material = greenMaterial;
            }
        }
    }

    private void AddImpulse(Vector3 direction)
    {
        myRigidbody.AddForce(direction * impulseForce, ForceMode.Impulse);
    }
}
