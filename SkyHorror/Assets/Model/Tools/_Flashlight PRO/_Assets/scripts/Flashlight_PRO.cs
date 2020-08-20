using UnityEngine;
using System.Collections;




public class Flashlight_PRO : MonoBehaviour 
{	
	[SerializeField()] GameObject Lights; 
	[SerializeField()] AudioSource switch_sound; 
	private Light spotlight;
	private Material ambient_light_material;	
	private bool is_enabled = false;

	void Start () 
	{
        spotlight = Lights.transform.Find("Spotlight").GetComponent<Light>();
        ambient_light_material = Lights.transform.Find("ambient").GetComponent<Renderer>().material;

        //устанавливаем начальное значение
        if (!is_enabled)
        { Lights.SetActive(false); }
        else
        { Lights.SetActive(true); }
	}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!is_enabled)
            {
                Lights.SetActive(true);
                if (switch_sound != null)
                { switch_sound.Play(); }
                is_enabled = true;
            }
            else
            {
                Lights.SetActive(false);
                is_enabled = false;
            }
        }
    }
}
