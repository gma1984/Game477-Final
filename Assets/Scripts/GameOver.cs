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
    }

    // Starts game
    public void LoadGame()
    {
        if (score == null)
        {
            if (GameObject.FindWithTag("Score") != null)
            {
                score = GameObject.FindWithTag("Score");
            }
            Destroy(score);
        }
        Time.timeScale = 1;
        SceneManager.LoadScene("Beta Scene");
    }
    public void LoadMenu()
    {
        if (score == null)
        {
            if (GameObject.FindWithTag("Score") != null)
            {
                score = GameObject.FindWithTag("Score");
            }
            Destroy(score);
        }
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
