using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTable : Interactive
{    
    public GameObject timeline;
    public GameObject trigger;
    public GameObject quest_1;
    public GameObject quest_2;
    public GameObject monitor;
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
                trigger.SetActive(true);
            }
            monitor.GetComponent<Outline>().enabled = false;
            quest_1.SetActive(false);
            quest_2.SetActive(true);
        }
    }    
}
