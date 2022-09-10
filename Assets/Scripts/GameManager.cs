using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    [SerializeField] Health playerHealth;
    [SerializeField] Health targetHealth;
    [SerializeField] Transform capsulePlayer;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI targetHealthText;
    int weapMode;
    // Start is called before the first frame update
    void Start()
    {
        weapMode = GameData.instance.weapMode;
        switchWeap(weapMode);
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Player Health: " + playerHealth.currentHealth.ToString();
        targetHealthText.text = "Target Health: " + targetHealth.currentHealth.ToString();
    }

    //public void ChangeWeapon()
    //{
    //    weapMode++;
        
    //    weapMode = weapMode >= weapons.Length ? 0 : weapMode;

    //    switchWeap(weapMode);
    //}

    void switchWeap(int mode)
    {
        for (int i = 0; i < weapons.Length; i++){
            if (i == mode)
            {
                //weapons[i].SetActive(true);
                GameObject go = Instantiate(weapons[i]);
                go.transform.parent = capsulePlayer;
            }
            //else
            //{
            //    weapons[i].SetActive(false);
            //}
        }
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER!");
    }
}
