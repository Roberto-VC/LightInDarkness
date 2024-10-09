using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField]
    private Material light;
    [SerializeField]
    private Material dark;

    private Renderer objectRenderer;
    private bool isLight = true;
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        // Set the initial material
        objectRenderer.material = light;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) // Change to the desired input if necessary
        {
            SwitchLight();
        }
    }

    private void SwitchLight()
    {
        if (isLight)
        {
            objectRenderer.material = dark;
        }
        else
        {
            objectRenderer.material = light;
        }

        isLight = !isLight;
    }
}
