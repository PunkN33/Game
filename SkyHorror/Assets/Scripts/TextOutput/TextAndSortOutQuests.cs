using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAndSortOutQuests : TextOutput
{     
    public GameObject quest;    
    public GameObject[] quests;  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _triggerEntered == true)
        {            
            Time.timeScale = 1;
            massage.SetActive(false);            
            gameManager.SetActive(true);
            for(int i =0;i<quests.Length;i++)
            {
                quests[i].SetActive(false);
            }
            quest.SetActive(true);                 
            Destroy(gameObject);
        }        
    }   
}
