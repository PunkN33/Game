using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToAnotherQuest : MonoBehaviour
{
    public GameObject[] viewObjects;
    public GameObject visibleQuest;
    public GameObject nextQuest;
    public GameObject trigger;
    public GameObject eva;
    private DialigIsEnabled dialog;
    private Collider evaTrigger;
    private int _counter = 0;
    private void Start()
    {
        dialog = eva.GetComponent<DialigIsEnabled>();
        evaTrigger = eva.GetComponent<BoxCollider>();
    }
    void Update()
    {
        _counter = 0;
        for (int i = 0; i < viewObjects.Length; i++)
        {
            if (viewObjects[i].GetComponent<View>()._once == true)
            {
                _counter = _counter + 1;
            }
        }

        if (trigger != null)
        {
            if (_counter >= 3)
            {
                trigger.SetActive(true);
                dialog.enabled = true;
                evaTrigger.enabled = true;
            }
            else
            {
                trigger.SetActive(false);
                dialog.enabled = false;
                evaTrigger.enabled = false;
            }
        }
    }
}
