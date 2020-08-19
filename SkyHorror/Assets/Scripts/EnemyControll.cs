using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemy;
    private float distance;
    private float radius;
    private bool boolean;
    private void Update()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i].GetComponent<NPCController1>().HP > 0)
            {
                distance = Vector3.Distance(player.transform.position, enemy[i].transform.position); 
                radius = enemy[i].GetComponent<NPCController1>().radius;
                boolean = enemy[i].GetComponent<NPCController1>()._once;
                if (distance > radius && boolean == false)
                {
                    enemy[i].SetActive(false);
                }
                else
                {
                    enemy[i].SetActive(true);                    
                }

            }

        }

    }
}
