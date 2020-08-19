using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialigIsEnabled : MonoBehaviour
{
    public GameObject useE;
    public GameObject cutScene;
    public GameObject key;
    private Outline _line;
    private bool _isEnabled = false;
    private bool _triggerEntered = false;
    void Start()
    {
        _line = GetComponent<Outline>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _triggerEntered == true)
        {
            if (!_isEnabled)
            {
                useE.SetActive(false);
                _line.enabled = false;
                cutScene.SetActive(true);
                _isEnabled = true;
                key.SetActive(true);
            }
            else
            {
                useE.SetActive(false);
                _line.enabled = false;
                _isEnabled = false;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            useE.SetActive(true);
            _line.enabled = true;
            _triggerEntered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            useE.SetActive(false);
            _line.enabled = false;
            _triggerEntered = false;
        }
    }
}
