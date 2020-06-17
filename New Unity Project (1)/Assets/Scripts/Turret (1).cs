using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret1 : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private GameObject prefabProjectile;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float maxImpulseForce = 10f;
    [SerializeField]
    private float minImpulseForce = 1f;
    [SerializeField]
    private float maxChargingTime = 3f;
    [SerializeField]
    private float minPitch = 1f;
    [SerializeField]
    private float maxPitch = 3f;
    [SerializeField]
    private AudioClip explosionSound;

    private float currentChargeTime;
    private AudioSource audioSource;

    private void Start()
    {
        currentChargeTime = 0f;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right, vertical * rotationSpeed * Time.deltaTime, Space.Self);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            currentChargeTime += Time.deltaTime;
            currentChargeTime = Mathf.Clamp(currentChargeTime, 0f, maxChargingTime);
            audioSource.pitch = Mathf.Lerp(minPitch, maxPitch, currentChargeTime / maxChargingTime);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            GameObject projectile = Instantiate(prefabProjectile, spawnPoint.position, Quaternion.identity);
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
            float impulseForce = Mathf.Lerp(minImpulseForce, maxImpulseForce, currentChargeTime / maxChargingTime);
            projectileRigidbody.AddForce(spawnPoint.forward * impulseForce, ForceMode.Impulse);
            currentChargeTime = 0f;
            audioSource.Stop();
            audioSource.pitch = minPitch;
            audioSource.PlayOneShot(explosionSound);
        }
    }
}
