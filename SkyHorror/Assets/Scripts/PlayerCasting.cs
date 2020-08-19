using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCasting : MonoBehaviour
{
    [HideInInspector]
    public static float DistanceFromTarget;
    private float Totarget;

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            Totarget = hit.distance;
            DistanceFromTarget = Totarget;
        }
    }   
}
