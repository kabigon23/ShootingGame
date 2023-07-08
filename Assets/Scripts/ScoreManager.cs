using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;
    public int currentScore;
    public Text bestScoreUI;
    public int bestScore;

    public void SetScore(int value)
    {
        currentScore = value;
        currentScore++;
        currentScoreUI.text = "현재 점수 : " + currentScore;
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreUI.text = "최고 점수 : " + bestScore;
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }
    public int GetScore()
    {
        return currentScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고 점수 : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
