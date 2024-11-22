using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static float maxHealth = 1000.0f;
    public static float currentHealth = 1000.0f;

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health

    }

    public static void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private static void Die()
    {
        // Handle death (e.g., play death animation, disable enemy)

        // Optionally, you can disable the enemy GameObject
    }

    public static float getHealth()
    {
        Debug.Log(currentHealth / maxHealth);
        return currentHealth / maxHealth;
    }

    public static void setHealth()
    {
        currentHealth = 1000.0f;
    }

}
