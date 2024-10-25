using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LifeManager : MonoBehaviour
{
    [SerializeField] public int lives = 3;
    [SerializeField] public int maxLives = 3;

    [SerializeField] private TextMeshProUGUI lifeUI;

    private void Start()
    {
        SetLifeText();
    }

    private void Update()
    {

    }

    public void DecreaseHealth()
    {
        lives = lives - 1;
        Debug.Log(lives);
        SetLifeText();
    }

    public void ResetHealth()
    {
       
        lives = maxLives;
        SetLifeText();
    }

    private void SetLifeText()
    {
        lifeUI.text = lives.ToString();
    }

}
