using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCutScene : MonoBehaviour
{
    public GameObject cutScene;
    void OnEnable()
    {
        cutScene.SetActive(true);
    }
}
