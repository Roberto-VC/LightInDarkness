using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public Transform GetPunto(int waypointIndice)
    {
        return transform.GetChild(waypointIndice);
    }

    public int GetNextPuntoIndex(int currentPunto)
    {
        int nextPunto = currentPunto + 1;

        if (nextPunto == transform.childCount)
        {
            nextPunto = 0;
        }

        return nextPunto;
    }
}
