using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    Rigidbody enemyRb;
    EnemyFire enemyFire;

    Animator enemyAnim;

    public bool isRange;
    float gap;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        enemyFire = FindObjectOfType<EnemyFire>();
        enemyRb = GetComponent<Rigidbody>();

        if (!isRange)
        {
            enemyAnim = GetComponent<Animator>();
            gap = 3f;
        }
        else
        {
            gap = 5f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < 20 && distance > gap)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, player.position, 5 * Time.deltaTime);

            transform.LookAt(player);

            enemyRb.MovePosition(pos);

            if (!isRange)
            {
                enemyAnim.SetBool("isMeleeAttack", false);
            }
        }
        else
        {
            enemyRb.velocity = Vector3.zero;
            enemyRb.angularVelocity = Vector3.zero;

            if (isRange && distance < gap)
            {
                enemyFire.Fire();
                transform.LookAt(player);
            }

            if(!isRange)
            {
                enemyAnim.SetBool("isMeleeAttack", true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("GET HIT!");
        }
    }
}
