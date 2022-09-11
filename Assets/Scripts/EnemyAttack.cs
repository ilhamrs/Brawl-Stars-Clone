using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Transform player;
    Rigidbody enemyRb;
    Animator enemyAnim;

    public bool isRange;
    public float gap;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Target").GetComponent<Transform>();
        enemyRb = GetComponent<Rigidbody>();
        enemyAnim = GetComponent<Animator>();
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("GET HIT!");
        }
    }
}
