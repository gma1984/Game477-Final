using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton() 
    {
        SceneManager.LoadScene("Alpha Room");
    }

}
