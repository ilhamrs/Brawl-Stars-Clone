using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject[] muzzlePosition;

    [SerializeField] float fireRate;

    bool allowFire;

    // Start is called before the first frame update
    void Start()
    {
        allowFire = true;
    }

    private void Awake()
    {
        allowFire = true;
    }

    public void Fire()
    {
        if (this.gameObject.activeInHierarchy)
        {
            if (allowFire)
            {
                StartCoroutine(spawnProjectile());
                Debug.Log("FIRE!");
            }
        }
    }

    IEnumerator spawnProjectile()
    {
        allowFire = false;
        for (int i= 0; i < muzzlePosition.Length; i++)
        {
            GameObject projectile = GameObject.Instantiate(projectilePrefab, muzzlePosition[i].transform.position, muzzlePosition[i].transform.rotation);
        }
        
        yield return new WaitForSeconds(fireRate);
        allowFire = true;
    }
}
