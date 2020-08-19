using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpWithDestroy : MonoBehaviour
{   
    public GameObject useE;
    public GameObject model;
    private Outline _line;

    private void Start()
    {
        _line = GetComponent<Outline>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            useE.SetActive(true);
            _line.enabled = true;
        }
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            useE.SetActive(false);
            Destroy(model);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            useE.SetActive(false);
            _line.enabled = false;
        }
    }
}
