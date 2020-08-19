using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWithQuest : TextOutput
{   
    public GameObject quest;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _triggerEntered == true)
        {            
            Time.timeScale = 1;
            massage.SetActive(false);
            gameManager.SetActive(true);
            quest.SetActive(true);
            Destroy(gameObject);            
        }
    } 
}
