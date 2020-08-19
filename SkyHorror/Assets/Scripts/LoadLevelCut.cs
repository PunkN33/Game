using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelCut : MonoBehaviour
{
    public string numberScene;   
   
    void OnEnable()
    {
        SceneManager.LoadScene(numberScene);
        //SceneManager.LoadScene( 2, LoadSceneMode.Additive);
        //GameObject.FindGameObjectWithTag("Player").SetActive(true);       
    }
}
