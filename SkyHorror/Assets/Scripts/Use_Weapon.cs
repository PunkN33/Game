using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Use_Weapon : MonoBehaviour
{    
    public Texture2D aim;
    public GameObject player;   
    public GameObject metalEffect;
    public GameObject bloodEffect;
    public GameObject muzzelSpawn;
    public GameObject[] muzzelFlash;
    public AudioSource shoot_sound_source;

    private Animator anim;
    private GameObject _holdFlash;
    private CounterAndHealth ammo;
    private int damage = 15;
    private float x = 100f, y = 70;

    private void Start()
    {
        ammo = player.GetComponent<CounterAndHealth>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Shooting();        
    }

    private void Shooting()
    {        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(ray.origin, transform.forward*10, Color.red, 1);

        if (Input.GetMouseButtonDown(0))
        {
            if (ammo.ammoShotgun > 0)
            {                
                int randomNumberForMuzzelFlash = Random.Range(0, 5);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider && hit.transform.tag != "Dummie")
                    {
                        GameObject g = Instantiate<GameObject>(metalEffect);
                        g.transform.position = hit.point + hit.normal * 0.01f;
                        g.transform.rotation = Quaternion.LookRotation(-hit.normal);
                        g.transform.SetParent(hit.transform);
                    }

                    if (hit.transform.tag == "Dummie")
                    {
                        GameObject b = Instantiate<GameObject>(bloodEffect);
                        b.transform.position = hit.point + hit.normal * 0.01f;
                        b.transform.rotation = Quaternion.LookRotation(-hit.normal);
                        b.transform.SetParent(hit.transform);

                        GameObject hitObj = hit.transform.gameObject; // получаем объект, в кот. попал луч

                        NPCController target = hitObj.GetComponent<NPCController>();
                        NPCController1 target1 = hitObj.GetComponent<NPCController1>();
                        if (target!=null)
                        {
                            target.HP = target.HP - damage;                            
                        }
                        if (target1 != null)
                        {
                            target1.HP = target1.HP - damage;
                        }
                    }
                    anim.SetTrigger("Attack");
                    if (shoot_sound_source)
                        shoot_sound_source.Play();

                    _holdFlash = Instantiate(muzzelFlash[randomNumberForMuzzelFlash], muzzelSpawn.transform.position /*- muzzelPosition*/, muzzelSpawn.transform.rotation * Quaternion.Euler(0, 0, 90)) as GameObject;
                    _holdFlash.transform.parent = muzzelSpawn.transform;

                    ammo.ammoShotgun -= 1;                   
                }
            }
        }
        if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Idle");
        }
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2 - x / 2, Screen.height / 2 - y / 2, x, y), aim);
    }
}
