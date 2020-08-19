using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slots : MonoBehaviour
{
    public Reel[] reel;    
    public Scene scene;
    public string numberScene;
    private bool _startSpin;
    private bool _endCoroutine = false;
    
    private void Start()
    {
        _startSpin = false;
        scene = SceneManager.GetActiveScene();
    }
    private void Update()
    {
        if (!_startSpin)
        {
            if (scene.isLoaded == true)
            {
                _startSpin = true;
                StartCoroutine(Spinning());               
            }            
        }  
        if (_endCoroutine == true)
        {
            SceneManager.LoadScene(numberScene);            
        }       
    }

    IEnumerator Spinning()
    {
        foreach (Reel spinner in reel)
        {           
            spinner.spin = true;
        }

        for (int i = 0; i < reel.Length; i++)
        {            
            yield return new WaitForSeconds(Random.Range(1, 4));
            reel[i].spin = false;
            reel[i].RandomPosition();
        }        
        _startSpin = true; 
        _endCoroutine = true;        
    }
}
