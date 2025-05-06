using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenu = null;
    public bool GetIsPaused() { return isPaused; }

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    // Starts game
    public void LoadGame()
    {
        SceneManager.LoadScene("Alpha Room");
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
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseMenu.SetActive(isPaused);

    }
}
