using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorsQuestEnemy : MonoBehaviour
{      
    public GameObject useE;
    public GameObject lockImage;    
    public GameObject enemy;
    public GameObject door;
    private NPCController _controller;
    private Outline _line;
    private bool _isEnabled = false;
    private float distance;

    private void Start()
    {
        _line = GetComponent<Outline>();
        _controller = enemy.GetComponent<NPCController>();              
    }
    private void Update()
    {
        distance = PlayerCasting.DistanceFromTarget;        
    }

    private void OnMouseOver()
    {
        if (_controller.HP > 0)
        {
            if (distance <= 2)
            {
                lockImage.SetActive(true);
                _line.enabled = true;
            }
        }
        else
        {
            if (distance <= 2)
            {
                useE.SetActive(true);
                _line.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (distance <= 2)
                {
                    if (!_isEnabled)
                    {
                        useE.SetActive(false);
                        _line.enabled = false;                        
                        door.GetComponent<Animator>().SetBool("character_nearby", true);
                        _isEnabled = true;
                    }
                    else
                    {
                        useE.SetActive(false);
                        _line.enabled = false;                        
                        door.GetComponent<Animator>().SetBool("character_nearby", false);
                        _isEnabled = false;
                    }
                }
            }
        }
    }
    private void OnMouseExit()
    {
        lockImage.SetActive(false);
        useE.SetActive(false);
        _line.enabled = false;
    }

}
