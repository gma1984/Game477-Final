using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivatePopup : MonoBehaviour
{

    public Pause pause;
    public GameObject popup;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePopup();
        }
    }

    // Starts game
    public void ClosePopup()
    {
        Time.timeScale = 1;
        pause.canPause = true;
        popup.SetActive(false);
    }
}
