using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;

    private CharacterController characterController;
    private PlayerInput playerInput;
    private Transform cameraTransform;
    private Animator animator;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Vector3 moveInput = new Vector3(playerInput.Move.x, 0f, playerInput.Move.y);
        Vector3 moveDirection = cameraTransform.TransformDirection(moveInput);
        moveDirection.y = 0f;
        moveDirection.Normalize();
        moveDirection *= moveInput.magnitude;
        characterController.Move(moveDirection * movementSpeed * Time.deltaTime);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(playerInput.MouseScreenPosition);
        if(playerPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 lookDirection = hitPoint - transform.position;
            lookDirection.Normalize();
            transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        }
        if(characterController.velocity.magnitude > 0f)
        {
            animator.SetBool("Moving", true);
            Vector3 localMovementDirection = transform.InverseTransformDirection(moveDirection);
            animator.SetFloat("Dir X", localMovementDirection.x);
            animator.SetFloat("Dir Y", localMovementDirection.z);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
}
