using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextShowsHighscore : MonoBehaviour {
    [SerializeField]
    private Text text;
    void Start()
    {
        Debug.Log("h");
        text.text = "Highscore: " + Data.personalHighScore.ToString();
    }
}
