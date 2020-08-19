using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController1 : MonoBehaviour
{
    public GameObject player;
    public GameObject ragdoll;   
    public bool _once = false;    
    public float HP = 100;
    public float radius = 20;
    public float distance;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = 30.0f;
    }

    public void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance > radius && _once == false)
        {
            _agent.enabled = false;            
            gameObject.GetComponent<Animator>().SetTrigger("Idle");            
        }
        if (distance > radius && _once == true && player.GetComponent<CounterAndHealth>().HP>0)
        {
            _agent.SetDestination(player.transform.position);
            gameObject.GetComponent<Animator>().SetTrigger("Run");            
        }
        if (distance < radius && distance > 6f && HP > 0 && player.GetComponent<CounterAndHealth>().HP > 0)
        {            
            _agent.enabled = true;
            gameObject.GetComponent<Animator>().SetBool("Spawn", true);
            _agent.SetDestination(player.transform.position);
            gameObject.GetComponent<Animator>().SetTrigger("Run"); 
            _once = true;
        }
        if (distance < 5f && HP > 0 && player.GetComponent<CounterAndHealth>().HP > 0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Attack");            
        }
        if (HP <= 0)
        {
            gameObject.SetActive(false);          
            GameObject clone = Instantiate(ragdoll, transform.position, transform.rotation);           
            Destroy(clone, 5f);
        }
        if (player.GetComponent<CounterAndHealth>().HP <= 0)
        {
            _agent.enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("Idle");
        }
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            HP = HP - 10;
        }
    }
}
