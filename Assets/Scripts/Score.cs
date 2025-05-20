using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using HighScore;

public class Score : MonoBehaviour
{
    public float timeScore = 60000f;
    public float decreaseRate = 50f;
    public bool timer = true;
    public float score;
    public static Score Instance {get; private set;}

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        HS.Init(this, "Randy Goes Bananas");
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            timeScore -= decreaseRate * Time.deltaTime;
        }
        if (timeScore < 0)
        {
            timeScore = 0;
        }
    }

    public void AddToScore(float amount)
    {
        score += amount;
    }

    public void timerStop()
    {
        timer = false;
    }

    public void addTimeScore()
    {
        score += timeScore;
    }

    public void SubmitScore(string scoreName) 
    {
        HS.SubmitHighScore(this, scoreName, (int)score);
    }
}
