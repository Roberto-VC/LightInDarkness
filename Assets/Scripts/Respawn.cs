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
            transform.position = new Vector3(-7.97f, 1.035f, -9.21f);
        }
    }
}
