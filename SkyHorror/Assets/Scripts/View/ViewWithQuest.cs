using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewWithQuest : Interactive
{    
    public GameObject[] quests;
    public GameObject nextQuest;
    public GameObject visibleQuest;        

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
                for (int i = 0; i < quests.Length; i++)
                {
                    quests[i].SetActive(false);
                }
                nextQuest.SetActive(true);
                visibleQuest.SetActive(false);
            }
            else
            {
                useE.SetActive(true);
                _line.enabled = true;
                Time.timeScale = 1;
                text.SetActive(false);
                _isEnabled = false;
            }
        }
    }
}
