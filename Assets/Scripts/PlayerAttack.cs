using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject muzzlePosition;

    [SerializeField] float fireRate;

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
        yield return new WaitForSeconds(fireRate);
        allowFire = true;
    }
}
