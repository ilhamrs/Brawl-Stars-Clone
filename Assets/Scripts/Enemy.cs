using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < 10 && distance > 4)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, player.position, 5 * Time.deltaTime);

            transform.LookAt(player);

            enemyRb.MovePosition(pos);
        }
        else
        {
            enemyRb.velocity = Vector3.zero;
            enemyRb.angularVelocity = Vector3.zero;
        }
        
    }
}
