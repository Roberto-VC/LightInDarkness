using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerColor : MonoBehaviour
{
    [SerializeField]
    private Material lightMaterial;  // Material claro
    [SerializeField]
    private Material darkMaterial;   // Material oscuro

    [SerializeField]
    private GameObject playerModel;  // Modelo del jugador que contiene el Renderer

    private Renderer modelRenderer;  // Renderer del modelo
    private bool isLight = true;

    void Start()
    {
        // Obtener el Renderer del modelo del jugador
        modelRenderer = playerModel.GetComponent<Renderer>();

        // Establecer el material inicial
        modelRenderer.material = lightMaterial;

        // Establecer la capa inicial del objeto que contiene el script
        gameObject.layer = LayerMask.NameToLayer("Light");  // Cambiar la capa del parent a "Light"
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) || Gamepad.all[0].rightShoulder.wasPressedThisFrame) // Cambia a la tecla o input deseado
        {
            SwitchLight();
        }
    }

    // Método para cambiar entre los materiales claro y oscuro
    private void SwitchLight()
    {
        if (isLight)
        {
            // Cambiar al material oscuro en el modelo
            modelRenderer.material = darkMaterial;

            // Cambiar la capa (Layer) del objeto que contiene el script a "Darkness"
            gameObject.layer = LayerMask.NameToLayer("Darkness");


        }
        else
        {
            // Cambiar al material claro en el modelo
            modelRenderer.material = lightMaterial;

            // Cambiar la capa (Layer) del objeto que contiene el script a "Light"
            gameObject.layer = LayerMask.NameToLayer("Light");

        }

        isLight = !isLight;  // Cambiar el estado de la luz
    }
}
