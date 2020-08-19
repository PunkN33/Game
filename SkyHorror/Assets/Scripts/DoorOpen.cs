using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{    
    public GameObject useE;
    public GameObject door;
    private Outline _line;
    private float distance;
    private bool _isEnabled = false;

    private void Start()
    {
        _line = GetComponent<Outline>();
    }
    private void Update()
    {
        distance = PlayerCasting.DistanceFromTarget;        
    }
    private void OnMouseOver()
    {
        if (distance <= 2)
        {
            useE.SetActive(true);
            _line.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (distance <= 2)
            {
                if (!_isEnabled)
                {
                    useE.SetActive(false);
                    _line.enabled = false;                    
                    door.GetComponent<Animator>().SetBool("character_nearby", true);
                    _isEnabled = true;
                }
                else
                {
                    useE.SetActive(false);
                    _line.enabled = false;                    
                    door.GetComponent<Animator>().SetBool("character_nearby", false);
                    _isEnabled = false;
                }
            }
        }
    }
    private void OnMouseExit()
    {
        useE.SetActive(false);
        _line.enabled = false;
    }
}
