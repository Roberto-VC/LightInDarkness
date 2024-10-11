using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform pointA;  // Primer punto (posición inicial)
    public Transform pointB;  // Segundo punto (posición final)
    public float speed = 2f;  // Velocidad de movimiento

    private Vector3 globalPointA;  // Posición global del punto A
    private Vector3 globalPointB;  // Posición global del punto B
    private bool movingToPointB = true;  // Controla la dirección de la plataforma

    [SerializeField]
    private GameObject platform;  // Referencia al objeto que será el parent del jugador (tiene el collider)

    private void Start()
    {
        // Guardar las posiciones globales de pointA y pointB
        globalPointA = pointA.position;
        globalPointB = pointB.position;
    }

    private void Update()
    {
        MovePlatform();
    }

    // Método para mover la plataforma entre dos puntos
    void MovePlatform()
    {
        if (movingToPointB)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, globalPointB, speed * Time.deltaTime);

            // Si la plataforma está cerca de B, cambiar dirección
            if (Vector3.Distance(platform.transform.position, globalPointB) < 0.1f)
            {
                movingToPointB = false;  // Cambiar la dirección a A
            }
        }
        else
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, globalPointA, speed * Time.deltaTime);

            // Si la plataforma está cerca de A, cambiar dirección
            if (Vector3.Distance(platform.transform.position, globalPointA) < 0.1f)
            {
                movingToPointB = true;  // Cambiar la dirección a B
            }
        }
    }

    // Detectar cuando el jugador toca la plataforma
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Hacer al jugador hijo de la plataforma para que se mueva con ella
            other.transform.SetParent(platform.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Liberar al jugador cuando sale de la plataforma
            other.transform.SetParent(null);
        }
    }
}
