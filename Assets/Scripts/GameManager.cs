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
    public TextMeshProUGUI enemyLeftText;
    public GameObject GameOverPanel;
    int weapMode;
    int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        weapMode = GameData.instance.weapMode;
        switchWeap(weapMode);
        GameOverPanel.SetActive(false);
        Time.timeScale = 1;

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(enemyCount);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length / 2;

        healthText.text = "Player Health: " + playerHealth.currentHealth.ToString();
        targetHealthText.text = "Target Health: " + targetHealth.currentHealth.ToString();

        enemyLeftText.text = "Enemy Left: " + enemyCount.ToString();

        if (playerHealth.currentHealth <= 0 || targetHealth.currentHealth <= 0 || enemyCount <= 0)
        {
            GameOver();
        }
    }

    void switchWeap(int mode)
    {
        for (int i = 0; i < weapons.Length; i++){
            if (i == mode)
            {
                GameObject go = Instantiate(weapons[i]);
                go.transform.parent = capsulePlayer;
            }
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
