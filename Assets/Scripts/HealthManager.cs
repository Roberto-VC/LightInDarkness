using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int maxHealth = 100;
    public static int currentHealth = 100;

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health
    }

    public static void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private static void Die()
    {
        // Handle death (e.g., play death animation, disable enemy)
        Debug.Log("Enemy died");
        // Optionally, you can disable the enemy GameObject
    }

}
