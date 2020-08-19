using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMan : MonoBehaviour
{
    public GameObject human;    
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            human.GetComponent<Animation>().Play("HandDown");
            Destroy(gameObject);
        }        
    }
}
