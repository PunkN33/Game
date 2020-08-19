using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{   
    public bool spin;
    private int speed;    
    private void Start()
    {
        spin = false;
        speed = 500;
    }
    private void Update()
    {
        if (spin)
        {
            foreach (Transform image in transform)
            {               
                image.transform.Translate(Vector3.down * Time.smoothDeltaTime * speed, Space.World);               
                if (image.transform.position.y <= 0) 
                { 
                    image.transform.position = new Vector3(image.transform.position.x, image.transform.position.y + 200, image.transform.position.z); 
                } 
            }
        }
    }    
    public void RandomPosition()
    {
        List<int> parts = new List<int>();

        //Add All Of The Values For The Original Y Postions         
        parts.Add(300);
        parts.Add(150);
        parts.Add(0);
        parts.Add(-150);
        parts.Add(-300);   

        foreach (Transform image in transform)
        {
            int rand = Random.Range(0, parts.Count);
            image.transform.position = new Vector3(image.transform.position.x, parts[rand] + transform.parent.GetComponent<RectTransform>().transform.position.y, image.transform.position.z);
            parts.RemoveAt(rand);
        }
    }
}

