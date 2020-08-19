using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipPatrol : MonoBehaviour
{    
    public Transform SpaceshipAI;
    public Transform point;    
    private float speed = 0.03f;       

    private void Update()
    {        
        transform.position = Vector3.Lerp(SpaceshipAI.position, point.position, speed*Time.deltaTime); 
    }    
}
