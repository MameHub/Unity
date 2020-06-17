using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material redMaterial;
    [SerializeField]
    private Material greenMaterial;
    
    private MeshRenderer cubeMeshRenderer;

    //Esta función se llama al empezar el juego.
    private void Start()
    {
        cubeMeshRenderer = GetComponent<MeshRenderer>();
    }

    //Esta función se llama cada frame.
    private void Update()
    {
        //GetKeyDown detecta la tecla que se pulsa en el primer frame.
        if(Input.GetKeyDown(KeyCode.A))
        {
            cubeMeshRenderer.material = redMaterial;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            cubeMeshRenderer.material = greenMaterial;
        }
    }
}
