using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
    public GameObject controls;
    public GameObject controlsButton;
    public GameObject resumeButton;
    public GameObject quitButton;
    public StartGame pauseTracker;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = true;
    }

    void Update()
    {
    }

    // Starts game
    public void OpenControls()
    {
        controls.SetActive(true);
        controlsButton.SetActive(false);
        resumeButton.SetActive(false);
        quitButton.SetActive(false);
    }
    public void CloseControls()
    {
        controls.SetActive(false);
        controlsButton.SetActive(true);
        resumeButton.SetActive(true);
        quitButton.SetActive(true);
    }
}
