using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject muzzlePosition;

    bool allowFire;

    // Start is called before the first frame update
    void Start()
    {
        allowFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        //GameObject projectile = GameObject.Instantiate(projectilePrefab, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
        if (allowFire)
        {
            StartCoroutine(spawnProjectile());
            Debug.Log("FIRE!");
        }
    }

    IEnumerator spawnProjectile()
    {
        allowFire = false;
        GameObject projectile = GameObject.Instantiate(projectilePrefab, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        allowFire = true;
    }
}
