using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOutput : MonoBehaviour
{
    public GameObject massage;
    public GameObject gameManager;
    [HideInInspector]
    public bool _triggerEntered = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Time.timeScale = 0;
            massage.SetActive(true);
            gameManager.SetActive(false);
            _triggerEntered = true;
        }
    }
}
