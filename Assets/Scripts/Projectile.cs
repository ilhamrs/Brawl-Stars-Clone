using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float Speed;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        projectilePrefab.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall")
        {
            DestroyProjectile();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            DestroyProjectile();
        }
    }
}
