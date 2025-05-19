using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputScore : MonoBehaviour
{
    public GameObject GameWinContainer;
    public GameObject InputContainer;
    public TMP_InputField scoreInput;
    private string scoreName;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //scoreName = scoreInput.text;
        //Debug.Log("Input text: " + scoreName);
    }

    public void Input() 
    {
        scoreName = scoreInput.text;
        Score.Instance.SubmitScore(scoreName);
        GameWinContainer.SetActive(true);
        InputContainer.SetActive(false);
    }
}