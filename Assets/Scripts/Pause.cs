using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenu;
    public GameObject controls;
    public GameObject controlsButton;
    public GameObject resumeButton;
    public GameObject quitButton;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = true;
    }

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

    // Starts game
    public void LoadGame()
    {
        SceneManager.LoadScene("Beta Room");
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        controls.SetActive(false);
        controlsButton.SetActive(true);
        resumeButton.SetActive(true);
        quitButton.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
