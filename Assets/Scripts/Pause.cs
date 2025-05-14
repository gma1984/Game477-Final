using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool isPaused;
    public Player_Controller player;
    public GameObject pauseMenu;
    public GameObject controls;
    public GameObject controlsButton;
    public GameObject resumeButton;
    public GameObject quitButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            UnpauseGame();
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void PauseGame()
    {
        player.DisableInput();
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void UnpauseGame()
    {
        player.EnableInput();
        isPaused = false;
        Time.timeScale = 1;
        controls.SetActive(false);
        controlsButton.SetActive(true);
        resumeButton.SetActive(true);
        quitButton.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
