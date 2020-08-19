using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewStim : Interactive
{    
    public GameObject timeline; 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _triggerEntered == true)
        {
            if (!_isEnabled)
            {
                useE.SetActive(false);
                _line.enabled = false;
                _marker.image.enabled = (false);
                Time.timeScale = 0;
                text.SetActive(true);
                _isEnabled = true;
            }
            else
            {
                useE.SetActive(true);
                _line.enabled = true;
                Time.timeScale = 1;
                text.SetActive(false);
                _isEnabled = false;

                timeline.SetActive(true);                
            }
        }
    }   
}
