using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public void UseWeapon(GameObject weapon)
    {
        weapon.SetActive(!weapon.activeSelf);
    }
}
