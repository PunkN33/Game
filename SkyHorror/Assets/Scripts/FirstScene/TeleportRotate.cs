using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRotate : MonoBehaviour
{   
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 2) * Time.deltaTime);
    }
}
