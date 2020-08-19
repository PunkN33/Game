using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramRotate : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 5) * Time.deltaTime);
    }
}
