using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject muzzlePosition;

    [SerializeField] float fireRate;

    bool allowFire;

    [SerializeField] Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        allowFire = true;
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if (allowFire)
        {
            StartCoroutine(spawnProjectile());
            Debug.Log("FIRE!");
        }

        //if (this.gameObject.activeInHierarchy)
        //{
        //    if (allowFire)
        //    {
        //        StartCoroutine(spawnProjectile());
        //        Debug.Log("FIRE!");
        //    }
        //}
    }

    IEnumerator spawnProjectile()
    {
        allowFire = false;
        GameObject projectile = GameObject.Instantiate(projectilePrefab, muzzlePosition.transform.position, muzzlePosition.transform.rotation);

        yield return new WaitForSeconds(fireRate);
        allowFire = true;
    }
}
