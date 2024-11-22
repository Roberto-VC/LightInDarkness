using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private bool isAttacking = false;
    public static int health = 100;
    [SerializeField]
    private ProgressBar progressBar;
    [SerializeField]
    private AudioSource audio;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        jumpsLeft = maxJumps; // Initialize jumps left

    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = characterController.isGrounded;
        float health = HealthManager.getHealth();
        progressBar.SetProgress(health);


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



        float deadZone = 0.1f; // Set an appropriate threshold for movement

        float movx = Input.GetAxis("Horizontal");
        float movz = Input.GetAxis("Vertical");

        if (health <= 0.0f)
        {
            movx = 0;
            movz = 0;
            jumpsLeft = 0;
            animator.SetBool("death", true);
        }
        else
        {
            animator.SetBool("death", false);
        }

        animator.SetFloat("inputH", movx);
        animator.SetFloat("inputV", movz);




        Vector3 movementVector = new Vector3(movx, 0, movz);
        movementVector = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementVector;
        movementVector = movementVector.normalized * speed;

        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {

            Jump();
        }

        Debug.DrawRay(gameObject.transform.position += new Vector3(0, 1, 0), gameObject.transform.forward * attackDistance, Color.red, 1.0f);

        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("Attack");
            Attack();
        }

        velocity.y += gravity * Time.deltaTime;
        float movementThreshold = 0.1f;

        if (movementVector.magnitude > movementThreshold)
        {
            transform.forward = movementVector; // Face the direction of movement

        }
        else
        {

        }

        characterController.Move((movementVector + velocity) * Time.deltaTime);

    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        jumpsLeft--;
        animator.SetBool("Ground", false);
        SoundManager.Instance.PlayJumpSound();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            HealthManager.TakeDamage(10);
        }
    }



    [Header("Atacar")]
    public float attackDistance = 3f;
    public float attackDelay = 0.4f;
    public float attackSpeed = 1f;
    public int attackDamage = 1;
    public LayerMask attackLayer;
    public AudioClip swordSwing;
    public AudioClip hitSound;

    bool attacking = false;
    bool readyToAttack = true;
    int attackCount;

    public void Attack()
    {
        if (!readyToAttack || attacking) return;

        readyToAttack = false;
        attacking = true;

        Invoke(nameof(ResetAttack), attackSpeed);
        Invoke(nameof(AttackRaycast), attackDelay);

        if (attackCount == 0)
        {
            attackCount++;
        }
        else
        {
            attackCount = 0;
        }
    }

    void ResetAttack()
    {
        attacking = false;
        readyToAttack = true;
    }

    void AttackRaycast()
    {
        // Convierte la capa actual del jugador a un LayerMask para el Raycast
        int playerLayer = gameObject.layer;
        LayerMask attackLayer = 1 << playerLayer; // Convierte la capa a LayerMask

        print("Capa actual del jugador: " + LayerMask.LayerToName(playerLayer));

        // Ajusta la posición inicial del Raycast 1 unidad hacia arriba
        Vector3 raycastOrigin = gameObject.transform.position + new Vector3(0, 1, 0);

        // Ejecuta el Raycast usando la capa actual del jugador
        if (Physics.Raycast(raycastOrigin, gameObject.transform.forward, out RaycastHit hit, attackDistance, attackLayer))
        {
            Destroy(hit.transform.gameObject);

            // Si el objeto golpeado tiene el componente Actor
            // Aca poner si el enemigo tiene un take damage
            // if (hit.transform.TryGetComponent<Actor>(out Actor actor))
            // {
            //     actor.TakeDamage(attackDamage);
            // }
        }
    }

    void HitTarget(Vector3 pos)
    {
        print(pos);
    }
}