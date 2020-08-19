using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUPWithQuest : Pick_Up
{
    public GameObject quest;
    private void Update()
    {
        distance = PlayerCasting.DistanceFromTarget;
        if (Input.GetKeyDown(KeyCode.E) && _on == true)
        {
            useE.SetActive(false);
            quest.SetActive(false);
        }
    }
}
