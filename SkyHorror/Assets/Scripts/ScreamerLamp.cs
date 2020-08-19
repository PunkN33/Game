using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerLamp : MonoBehaviour
{
    public GameObject lamp;
    public GameObject particles;    
    public AudioClip boom;
    private AudioSource _sorce;

    private void Start()
    {
        _sorce = lamp.GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            particles.SetActive(true);
            lamp.GetComponent<Animation>().Play("LampAnimation");
            _sorce.PlayOneShot(boom);
            Destroy(gameObject);
        }
    }
}
