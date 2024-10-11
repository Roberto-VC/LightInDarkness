using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLight : MonoBehaviour
{
    [SerializeField]
    private LayerMask targetLayer;  // Capa con la que se comparará

    void Start()
    {
        // Asegurarse de que la plataforma esté activa al inicio
        gameObject.layer = targetLayer;
    }


    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto tiene el tag "Player" y la capa correspondiente
        if (other.gameObject.tag.Equals("Player") && (targetLayer == (targetLayer | (1 << other.gameObject.layer))))
        {
            // Hacer al jugador hijo de la plataforma
            other.gameObject.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto tiene el tag "Player" y la capa correspondiente
        if (other.gameObject.tag.Equals("Player"))
        {
            // Liberar al jugador de la plataforma
            other.gameObject.transform.parent = null;
        }
    }
}
