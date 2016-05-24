using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextShowsHighscore : MonoBehaviour {
    [SerializeField]
    private Text text;
    void Start()
    {
        text.text = "Highscore: " + Data.personalHighScore.ToString();
    }
}
