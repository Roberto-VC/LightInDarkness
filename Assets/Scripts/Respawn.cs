using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField]
    public float threshold;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = new Vector3(-7.97f, 2.5f, -9.21f);
        }
        if (HealthManager.getHealth() <= 0.0)
        {
            StartCoroutine(RespawnAfterDelay(4f));
        }
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Wait for 'delay' seconds
        transform.position = new Vector3(-7.97f, 2.0f, -9.21f);
        HealthManager.setHealth();  // Call the method to reset health after delay
    }
}
