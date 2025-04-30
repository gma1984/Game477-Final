using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum ColorState { None, Red, Green, Blue, Yellow, Cyan, Magenta, White }

public class Player_ActivateColors : MonoBehaviour
{
    public GameObject redSignal;
    public GameObject greenSignal;
    public GameObject blueSignal;
    public GameObject yellowSignal;
    public GameObject cyanSignal;
    public GameObject magentaSignal;
    public GameObject whiteSignal;
    private bool redOn = false;
    //private bool greenOn = false;
    //private bool blueOn = false;
    //private bool yellowOn = false;
    //private bool purpleOn = false;
    //private bool cyanOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !redOn)
        {
            redSignal.SetActive(true);
            redOn = !redOn;
        }

        else if (Input.GetKeyDown(KeyCode.R) && redOn)
        {
            redSignal.SetActive(false);
            redOn = !redOn;
        }
    }
}