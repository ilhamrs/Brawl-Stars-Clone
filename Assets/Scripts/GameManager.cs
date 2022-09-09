using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    int weapMode;
    // Start is called before the first frame update
    void Start()
    {
        weapMode = 0;
        switchWeap(weapMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeWeapon()
    {
        weapMode++;
        
        weapMode = weapMode >= weapons.Length ? 0 : weapMode;

        switchWeap(weapMode);
    }

    void switchWeap(int mode)
    {
        for (int i = 0; i < weapons.Length; i++){
            if (i == mode)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }
}
