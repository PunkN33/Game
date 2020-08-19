using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUP_Weapon : Pick_Up
{
    private void Update()
    {
        distance = PlayerCasting.DistanceFromTarget;
        if (Input.GetKeyDown(KeyCode.E) && _on == true)
        {
            useE.SetActive(false);            
        }
    }   
}
