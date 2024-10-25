using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : PlatformLight
{
    [SerializeField]
    private WayPoints camino;
    [SerializeField]
    private float velocidad;
    private int indice;

    private Transform anterior;
    private Transform actual;

    private float tiempo = 5;
    private float elapsed;

    // Nuevo campo serializado para elegir la capa desde el Inspector
    

    // Start is called before the first frame update
    void Start()
    {
        Siguiente();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsed += Time.deltaTime;
        float elapsedPercent = elapsed / 5;
        elapsedPercent = Mathf.SmoothStep(0, 1, elapsedPercent);
        transform.position = Vector3.Lerp(anterior.position, actual.position, elapsedPercent);
        transform.rotation = Quaternion.Lerp(anterior.rotation, actual.rotation, elapsedPercent);

        if (elapsedPercent >= 1)
        {
            Siguiente();
        }
    }

    private void Siguiente()
    {
        anterior = camino.GetPunto(indice);
        
        indice = camino.GetNextPuntoIndex(indice);
        
        actual = camino.GetPunto(indice);

        elapsed = 0;
        float distancia = Vector3.Distance(anterior.position, actual.position);
        tiempo = distancia / velocidad;
    }
}
