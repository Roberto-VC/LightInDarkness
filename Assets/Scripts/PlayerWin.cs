using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject end;
    Vector3 ending;
    [SerializeField]
    private GameObject WinScreen;

    void Start()
    {
        ending = end.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            WinScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
