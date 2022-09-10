using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    Rigidbody enemyRb;
    //bool isAttacking;
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
        //isAttacking = false;

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
                //StartCoroutine(Attack());
                enemyAnim.SetBool("isMeleeAttack", true);

            }
            
        }
        
    }

    //IEnumerator Attack()
    //{
    //    Vector3 lastPos = player.position;
        
    //    yield return new WaitForSeconds(1f);
    //    Vector3 pos = Vector3.MoveTowards(transform.position, lastPos, 20 * Time.deltaTime);
    //    transform.LookAt(player);
    //    enemyRb.MovePosition(pos);
    //    yield return new WaitForSeconds(1f);

    //    Destroy(this.gameObject);

    //    //Vector3 pos2 = Vector3.MoveTowards(transform.position, -player.position, 50 * Time.deltaTime);
    //    //enemyRb.MovePosition(pos);
    //    //yield return new WaitForSeconds(3f);
    //    //isAttacking = false;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("GET HIT!");
        }
    }
}
