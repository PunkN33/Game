using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCutScene : MonoBehaviour
{
    public GameObject cutScene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        { 
            cutScene.SetActive(true);
        }
    }
}
