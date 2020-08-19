using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string numberScene;
    public string playerTag;   
    [SerializeField()] AudioSource sound;     

    private void OnTriggerStay(Collider other)
    {        
        if (other.tag == playerTag)
        {            
            if (sound != null)
                sound.Play();            
            SceneManager.LoadScene(numberScene);
        }
    }
}
