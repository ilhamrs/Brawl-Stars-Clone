using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    [SerializeField] Health playerHealth;
    [SerializeField] Health targetHealth;
    [SerializeField] Transform capsulePlayer;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI targetHealthText;
    public GameObject GameOverPanel;
    int weapMode;
    // Start is called before the first frame update
    void Start()
    {
        weapMode = GameData.instance.weapMode;
        switchWeap(weapMode);
        GameOverPanel.SetActive(false);
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Player Health: " + playerHealth.currentHealth.ToString();
        targetHealthText.text = "Target Health: " + targetHealth.currentHealth.ToString();

        if (playerHealth.currentHealth <= 0 || targetHealth.currentHealth <= 0)
        {
            GameOver();
        }
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
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
