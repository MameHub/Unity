using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punto : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.AnadirPunto();
            Destroy(gameObject);
        }
    }
}
