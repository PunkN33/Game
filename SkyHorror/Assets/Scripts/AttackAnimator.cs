using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimator : MonoBehaviour
{
    public GameObject weapon;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.GetComponent<Animator>().SetTrigger("Attack");
        }
        if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.GetComponent<Animator>().SetTrigger("Idle");
        }
    }
}
