using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject score = null;

    void Start()
    {
        if (score == null)
        {
            if (GameObject.FindWithTag("Score") != null)
            {
                score = GameObject.FindWithTag("Score");
            }
            Destroy(score);
        }
    }

    // Starts game
    public void LoadGame()
    {
        SceneManager.LoadScene("Beta Scene");
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
