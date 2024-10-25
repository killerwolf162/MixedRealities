using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public int score = 0;
    [SerializeField] private TextMeshProUGUI scoreUI;

    void Start()
    {
        SetScoreText();
    }

    public void IncreaseScore()
    {
        score += 1;
        SetScoreText();
    }

    public void ResetScore()
    {
        score = 0;
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreUI.text = score.ToString();
    }
}
