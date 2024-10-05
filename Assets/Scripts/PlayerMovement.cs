using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float speed = 5f;
    [SerializeField]
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    private CharacterController CharacterController;
    private Rigidbody RigidBody;

    private bool isGrounded;
    private Vector3 velocity;

    // New Jump variables
    [SerializeField]
    public int maxJumps = 2; // How many jumps are allowed
    private int jumpsLeft;
    public Animator animator;


    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        RigidBody = GetComponent<Rigidbody>();


    }



    void Update()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0; // Reset vertical velocity when grounded
        }

        if (velocity.y == 0)
        {
            jumpsLeft = maxJumps;
        }
        Debug.Log(jumpsLeft);

        float movx = Input.GetAxis("Horizontal");
        float movz = Input.GetAxis("Vertical");

        animator.SetFloat("inputH", movx);
        animator.SetFloat("inputV", movz);

        Vector3 movementVector = new Vector3(movx, 0, movz);

        if (movementVector.magnitude != 0)
        {
            transform.forward = movementVector;
            CharacterController.SimpleMove(movementVector * speed);
        }

        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            Debug.Log(":)");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Calculate jump velocity
            jumpsLeft--; // Decrease jumps left
        }


        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Move the character controller
        CharacterController.Move(velocity * Time.deltaTime);


    }
}
