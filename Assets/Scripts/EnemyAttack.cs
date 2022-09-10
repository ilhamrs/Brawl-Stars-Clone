using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Rigidbody enemyRb;
    bool isAttacking;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        //yield return new WaitForSeconds(0.5f);
        Vector3 pos = Vector3.MoveTowards(transform.position, player.position, 50 * Time.deltaTime);
        transform.LookAt(player);
        enemyRb.MovePosition(pos);
        //yield return new WaitForSeconds(0.5f);
        Vector3 pos2 = Vector3.MoveTowards(transform.position, -player.position, 50 * Time.deltaTime);
        enemyRb.MovePosition(pos);
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("GET HIT!");
        }
    }
}
