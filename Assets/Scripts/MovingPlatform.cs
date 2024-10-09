using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
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
        Debug.Log(indice);
        indice = camino.GetNextPuntoIndex(indice);
        Debug.Log(indice);
        actual = camino.GetPunto(indice);

        elapsed = 0;
        float distancia = Vector3.Distance(anterior.position, actual.position);
        tiempo = distancia / velocidad;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.transform.parent = null;
        }
    }

}
