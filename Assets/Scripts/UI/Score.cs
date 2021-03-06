﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {
    private static float score = 0;
    private char[] characters = new char[5];
    [SerializeField]
    private Text[] scoreTexts;
    void Start()
    {
        EventManager.OnDamage += AddScore;
        UpdateScore();
    }
    public void AddScore(float increment)
    {
        ScoreData.AddValue(increment);
        UpdateScore();
    }
    public void UpdateScore()
    {
        score = ScoreData.score;

        characters = score.ToString().ToCharArray();
        for (int s = 0; s < scoreTexts.Length; s++)
        {
            if(s < characters.Length)
            {
                scoreTexts[s].text = characters[characters.Length -s-1].ToString();
            }
            else
            {
                scoreTexts[s].text = "0";
            }
        }
    }
}
