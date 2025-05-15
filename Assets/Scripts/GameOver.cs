using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject score = null;
    public Pause pause;
    public GameObject gameOver;

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
        Time.timeScale = 1;
        SceneManager.LoadScene("Beta Scene");
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
