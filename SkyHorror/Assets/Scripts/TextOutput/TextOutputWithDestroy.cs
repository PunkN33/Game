using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOutputWithDestroy : TextOutput
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {            
            Time.timeScale = 1;
            massage.SetActive(false);           
            gameManager.SetActive(true);
            Destroy(gameObject);
        }        
    }   
}
