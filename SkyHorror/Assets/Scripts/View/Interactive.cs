using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public GameObject useE;
    public GameObject text;
    [HideInInspector]
    public Outline _line;
    [HideInInspector]
    public bool _isEnabled = false;
    [HideInInspector]
    public bool _triggerEntered = false;
    protected QuestMarker _marker;
    protected void Start()
    {
        _line = GetComponent<Outline>();
        _marker = GetComponent<QuestMarker>();
    }    
    protected void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            useE.SetActive(true);
            _line.enabled = true;
            _triggerEntered = true;
        }
    }
    protected void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            useE.SetActive(false);
            _line.enabled = false;
            _triggerEntered = false;
        }
    }    
}
