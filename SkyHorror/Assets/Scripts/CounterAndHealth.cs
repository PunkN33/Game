using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterAndHealth : MonoBehaviour
{   
    public GameObject deathScreen;
    public Text counterHP;    
    public Image UIHP;    
    public Text counterRifle;    
    public Text counterShotgun;
    public float HP = 1f;
    public int ammoRifle = 0;
    public int ammoShotgun = 0;
    private int HPBag = 0;    

    private void Update()
    {
        UIHP.fillAmount = HP;
        counterHP.text = "" + HPBag;
        counterRifle.text = "" + ammoRifle;
        counterShotgun.text = "" + ammoShotgun;

        if (Input.GetKeyDown(KeyCode.H) && HPBag > 0f && HP < 1f)
        {
            HP = HP + 0.6f;
            HPBag -= 1;
        }
        if (HP > 1f)
        {
            HP = 1f;
        }
        if(HP<=0)
        {
            GetComponent<FPSController>().speed = 0;
            GetComponent<FPSController>().head.localEulerAngles = new Vector3(0,0,0);
            
            deathScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.tag == "HPBag")
            {
                HPBag += 1;                
            }
            if (other.tag == "Rifle")
            {
                ammoRifle += 1;                
            }
            if (other.tag == "Shotgun")
            {
                ammoShotgun += 10;                
            }
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPCWeapon")
        {
            HP = HP - 0.02f;
        }
        if (other.tag == "NPCBoss")
        {
            HP = HP - 0.1f;
        }
    }
}
