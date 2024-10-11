using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 50f;  // Velocidad de rotación

    void Update()
    {
        RotatePlatform();
    }

    // Método para rotar la plataforma sobre sí misma
    void RotatePlatform()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
