using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI txtDisplayScore;
    private float displayScore;

    // Update is called once per frame
    void Update()
    {
        displayScore = Score.Instance.score;
        txtDisplayScore.text = displayScore.ToString("00000");
    }
}
