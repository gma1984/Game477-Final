using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI txtFinalScore;
    public GameObject score = null;
    private float finalScore;

    // Start is called before the first frame update
    void Start()
    {
        finalScore = Score.Instance.score;
        txtFinalScore.text = finalScore.ToString("00000");
        if (score == null)
        {
            if (GameObject.FindWithTag("Score") != null)
            {
                score = GameObject.FindWithTag("Score");
            }
            Destroy(score);
        }
    }
}
