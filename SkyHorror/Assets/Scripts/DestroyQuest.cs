using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyQuest : MonoBehaviour
{
    public GameObject quest;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(quest);
        }
    }


}
