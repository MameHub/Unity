using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOtherObjectColor : MonoBehaviour
{
    [SerializeField]
    private GameObject otherGameObject;
    [SerializeField]
    private Material redMaterial;
    [SerializeField]
    private Material greenMaterial;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            otherGameObject.GetComponent<MeshRenderer>().material = redMaterial;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            otherGameObject.GetComponent<MeshRenderer>().material = greenMaterial;
        }

        int randomNumber = Random.Range(0, 20);
    }
}
