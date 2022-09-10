using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Transform player;
    Rigidbody enemyRb;
    //bool isAttacking;
    EnemyFire enemyFire;

    Animator enemyAnim;

    public bool isRange;
    public float gap;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Target").GetComponent<Transform>();
        enemyFire = FindObjectOfType<EnemyFire>();
        enemyRb = GetComponent<Rigidbody>();
        //isAttacking = false;

        enemyAnim = GetComponent<Animator>();

        //if (!isRange)
        //{
            
        //    gap = 3f;
        //}
        //else
        //{
        //    gap = 5f;
        //}

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= gap)
        {
            enemyRb.velocity = Vector3.zero;
            enemyRb.angularVelocity = Vector3.zero;
            enemyAnim.SetBool("isMeleeAttack", true);
        }
        else
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, player.position, 5 * Time.deltaTime);

            transform.LookAt(player);

            enemyRb.MovePosition(pos);

            enemyAnim.SetBool("isMeleeAttack", false);
        }

        //if (distance < 10 && distance > gap)
        //{
            

        //    if (!isRange)
        //    {
                
        //    }
        //}
        //else
        //{

            

        //    if (isRange && distance < gap)
        //    {
        //        enemyFire.Fire();
        //        transform.LookAt(player);
        //    }

        //    if (!isRange)
        //    {
        //        //StartCoroutine(Attack());
                

        //    }

        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("GET HIT!");
        }
    }
}
