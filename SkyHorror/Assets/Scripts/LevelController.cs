using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    //[HideInInspector]
    public bool isComplete;
    //[HideInInspector]
    public int sceneIndex;
    public

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        isComplete = true;
    }
}
