using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject controlPanel;
    public GameObject weaponPanel;
    // Start is called before the first frame update
    void Start()
    {
        controlPanel.SetActive(false);
        weaponPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        controlPanel.SetActive(false);
        weaponPanel.SetActive(false);
    }

    public void OpenControl()
    {
        controlPanel.SetActive(true);
    }

    public void OpenWeapon()
    {
        weaponPanel.SetActive(true);
    }

    public void StartGame(int weap)
    {
        GameData.instance.weapMode = weap;
        SceneManager.LoadScene("Gameplay");

    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}
