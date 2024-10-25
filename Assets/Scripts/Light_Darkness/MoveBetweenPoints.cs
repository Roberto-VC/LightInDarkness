using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    [SerializeField] private Transform pointA;  // Primer punto
    [SerializeField] private Transform pointB;  // Segundo punto
    [SerializeField] private float speed = 2.0f; // Velocidad de movimiento

    private Vector3 initialPositionA;  // Posición original del punto A
    private Vector3 initialPositionB;  // Posición original del punto B
    private Vector3 targetPosition;    // Posición objetivo
    private bool movingToPointB = true; // Controlar la dirección del movimiento

    void Start()
    {
        // Guardar las posiciones originales de los puntos A y B
        initialPositionA = pointA.position;
        initialPositionB = pointB.position;

        // Establecer el primer objetivo como la posición original de pointB
        targetPosition = initialPositionB;
    }

    void Update()
    {
        // Mover el objeto hacia el objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Cambiar el objetivo cuando el objeto llegue al punto
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (movingToPointB)
            {
                targetPosition = initialPositionA; // Cambiar objetivo a la posición original de pointA
            }
            else
            {
                targetPosition = initialPositionB; // Cambiar objetivo a la posición original de pointB
            }

            movingToPointB = !movingToPointB; // Cambiar la dirección del movimiento
        }
    }
}
