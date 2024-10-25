using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField]
    public Transform player; // Assign the player Transform in the Inspector
    [SerializeField]
    public float detectionRange = 10f; // Distance at which AI will start moving towards the player
    [SerializeField]
    public float stopRange = 2f; // Distance at which AI will stop moving towards the player

    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        bool isMoving = false;

        if (distanceToPlayer < detectionRange)
        {
            if (distanceToPlayer > stopRange)
            {
                agent.SetDestination(player.position); // Move towards the player
                isMoving = true;
            }
            else
            {
                agent.ResetPath(); // Stop moving when within stop range
            }
        }
        else
        {
            agent.ResetPath(); // Stop moving if outside detection range
        }

        // Update animation parameter
        animator.SetBool("isMoving", isMoving);
    }
}