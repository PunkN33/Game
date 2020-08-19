using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShip : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Spaceship")
        {
            Destroy(col.gameObject);            
        }
        Destroy(gameObject);
    }    
}
