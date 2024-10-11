using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;
    [SerializeField]
    public float jumpHeight = 1f;
    public float gravity = -9.81f;

    private CharacterController characterController;

    private bool isGrounded;
    private Vector3 velocity;

    [SerializeField]
    public int maxJumps = 2; // How many jumps are allowed
    private int jumpsLeft;
    public Animator animator;

    [SerializeField]
    private Transform cameraTransform;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        jumpsLeft = maxJumps; // Initialize jumps left
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = characterController.isGrounded;

        // Reset vertical velocity and jumps when grounded
        if (isGrounded)
        {
            if (velocity.y < 0)
            {
                velocity.y = 0;
            }
            jumpsLeft = maxJumps;
            animator.SetBool("Ground", true);
        }

        float movx = Input.GetAxis("Horizontal");
        float movz = Input.GetAxis("Vertical");

        animator.SetFloat("inputH", movx);
        animator.SetFloat("inputV", movz);



        Vector3 movementVector = new Vector3(movx, 0, movz);
        movementVector = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementVector;
        movementVector = movementVector.normalized * speed;

        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            Jump();
        }

        velocity.y += gravity * Time.deltaTime;

        if (movementVector != Vector3.zero)
        {
            transform.forward = movementVector; // Face the direction of movement
        }
        characterController.Move((movementVector + velocity) * Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        jumpsLeft--;
    }
}