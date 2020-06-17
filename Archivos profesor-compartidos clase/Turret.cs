using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private GameObject prefabProjectile;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float impulseForce = 10f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right, vertical * rotationSpeed * Time.deltaTime, Space.Self);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate(prefabProjectile, spawnPoint.position, Quaternion.identity);
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
            projectileRigidbody.AddForce(spawnPoint.forward * impulseForce, ForceMode.Impulse);
        }
    }
}
