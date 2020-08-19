using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource idle;
    public AudioSource attack;
    public AudioSource attack1;
    public bool isEnabledIdle = false;
    public bool isEnabledAttack = false;
    public bool isEnabledAttack1 = false;
    void Start()
    {
        idle = GetComponent<AudioSource>();
        attack = GetComponent<AudioSource>();
        attack1 = GetComponent<AudioSource>();
    }

    public void OnEnable()
    {
        if (!isEnabledIdle)
        {
            idle.enabled = true;
            idle.Play();
        }
        if (isEnabledIdle)
        {
            idle.enabled = false;
        }
        if (!isEnabledAttack)
        {
            attack.enabled = true;
            attack.Play();
        }
        if (isEnabledAttack)
        {
            attack.enabled = false;
        }
        if (!isEnabledAttack1)
        {
            attack1.enabled = true;
            attack1.Play();
        }
        if (isEnabledAttack1)
        {
            attack1.enabled = false;
        }
    } 
}
