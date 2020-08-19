using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{    
    public GameObject useE;    
    protected float distance;    
    protected Outline _line; 
    protected bool _on = false;
    protected void Start()
    {
        _line = GetComponent<Outline>();
    }
    protected void OnMouseOver()
    {
        if (distance <= 2)
        {
            useE.SetActive(true);
            _line.enabled = true;
            _on = true;
        }
    }
    protected void OnMouseExit()
    {
        useE.SetActive(false);
        _line.enabled = false;
    }
}
