﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnlockButton : MonoBehaviour {

    [SerializeField]
    private int level = 0;
    private bool unlocked = false;
    private Image image;

    void OnEnable()
    {
        image = GetComponent<Image>();
        CheckIfUnlock();
    }	
    void CheckIfUnlock()
    {
        Debug.Log(Data.levelData);

        if (Data.levelData >= level)
        {
            unlocked = true;
            image.color = Color.white;
        }
        else
        {
            unlocked = false;
            image.color = Color.red;
        }
    }
    public void Clicked()
    {
        if(unlocked)
        {
            SceneManager.LoadScene("Level" + level.ToString());
        }
    }
}
