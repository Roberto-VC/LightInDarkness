using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursedItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collider)
    {
        // Verifica si el objeto con el que colisiona tiene el tag "Player" y está en una capa diferente
        if (collider.gameObject.CompareTag("Player") && collider.gameObject.layer != gameObject.layer)
        {
            HealthManager.TakeDamage(10);
            print("Cambia de color!!");
        }
    }

}
