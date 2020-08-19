using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public GameObject player;
    public GameObject ragdoll;
    public float HP = 100;
    private float distance;    
    private float radius = 15;       
    private NavMeshAgent _agent;
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = 20.0f;
    }

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance > radius)
        {
            _agent.enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("Idle");
        }
        if (distance < radius && distance > 6f && HP > 0 && player.GetComponent<CounterAndHealth>().HP > 0)
        {
            _agent.enabled = true;           
            _agent.SetDestination(player.transform.position);            
            gameObject.GetComponent<Animator>().SetTrigger("Run");
        }
        if (distance < 5f && HP > 0 && player.GetComponent<CounterAndHealth>().HP > 0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Attack");
        }
        if (HP <= 0)
        {                
            Destroy(this.gameObject);
            GameObject clone = Instantiate(ragdoll, transform.position, transform.rotation);
            Destroy(clone, 5f);
        }
        if(player.GetComponent<CounterAndHealth>().HP<=0)
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
