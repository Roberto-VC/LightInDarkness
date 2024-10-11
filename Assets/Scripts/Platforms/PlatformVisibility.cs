using UnityEngine;

public class PlatformVisibility : MonoBehaviour
{
    public float visibleTime = 3f;  // Tiempo que la plataforma será visible
    public float invisibleTime = 2f;  // Tiempo que la plataforma estará invisible

    private bool isVisible = true;
    private float visibilityTimer = 0f;

    [SerializeField]
    private GameObject platform;

    void Start()
    {
        // Asegurarse de que la plataforma esté activa al inicio
        platform.SetActive(true);
    }

    void Update()
    {
        HandleVisibility();
    }

    // Método para manejar la visibilidad de la plataforma
    void HandleVisibility()
    {
        visibilityTimer += Time.deltaTime;

        if (isVisible && visibilityTimer >= visibleTime)
        {
            // Hacer invisible la plataforma y reiniciar el temporizador
            platform.SetActive(false);
            isVisible = false;
            visibilityTimer = 0f;  // Reiniciar el temporizador después del cambio
        }
        else if (!isVisible && visibilityTimer >= invisibleTime)
        {
            // Hacer visible la plataforma y reiniciar el temporizador
            platform.SetActive(true);
            isVisible = true;
            visibilityTimer = 0f;  // Reiniciar el temporizador después del cambio
        }
    }
}
