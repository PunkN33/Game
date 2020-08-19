using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseFlashlight : MonoBehaviour
{
    public GameObject Lights;
    public AudioSource switch_sound;       
    private bool _is_enabled = false;
    void Start()
    {   
        //устанавливаем начальное значение
        if (!_is_enabled)
        { Lights.SetActive(false); }
        else
        { Lights.SetActive(true); }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!_is_enabled)
            {
                Lights.SetActive(true);
                if (switch_sound != null)
                { switch_sound.Play(); }
                _is_enabled = true;
            }
            else
            {
                Lights.SetActive(false);
                _is_enabled = false;
            }
        }
    }
}
