using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WinLoseStateManager : MonoBehaviour {


    private int levelCount = 2;
    [SerializeField]
    private int levelNumber = 1;

    [SerializeField]
    private SceneLoader sceneLoader;
    [SerializeField]
    private TimeLeft timer;
    [SerializeField]
    private Score score;

    [SerializeField]
    private Text conditionText;
    [SerializeField]
    private GameObject conditionHolder;

    [SerializeField]
    private GameObject introHolder;
    [SerializeField]
    private Text introText;
    [SerializeField]
    private Text levelText;
    void Start()
    {
        EventManager.OnHittingPlayer += Lost;
        EventManager.OnWinning += Win;
        StartCoroutine(Intro(2,0.001f));
    }
    private IEnumerator Intro(float duration, float timeScale)
    {
        levelText.text = "level " + levelNumber.ToString();
        Time.timeScale = timeScale;
        int i = 0;
        while(i <3)
        {
            introText.text = 3-i+ "";
            i++;
            yield return new WaitForSeconds((duration*timeScale)/4);
        }
        introText.text = "Go!";
        yield return new WaitForSeconds((duration * timeScale) / 4);
        introHolder.SetActive(false);
        Time.timeScale = 1;
    }
    public void Lost(float timeScale, float duration,string text)
    {
        StartCoroutine(Losing(timeScale, duration, text));
    }
    IEnumerator Losing(float timeScale, float duration, string text)
    {
        conditionHolder.SetActive(true);
        conditionHolder.GetComponent<Image>().color = Color.red;
        conditionText.text = text;
        Time.timeScale = timeScale;
        yield return new WaitForSeconds(duration*timeScale);
        Time.timeScale = 1f;
        sceneLoader.RestartScene();
    }
    public void Win(float duration, string text)
    {
        StartCoroutine(Winning(duration, text));
    }
    IEnumerator Winning(float duration, string text)
    {
        AudioSource source = GetComponent<AudioSource>();
        timer.TimeScaling = 10;
        conditionHolder.SetActive(true);
        conditionText.text = text;
        while (timer.TimeLimit > 0)
        {
            score.AddScore(1);
            source.Play();
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(duration);
        if(levelNumber >= LevelData.maxLevel)
        {
            conditionText.fontSize = 60;
            conditionText.text = "you have beaten \n the game!";
            Debug.Log("you have beaten the game!");
        }
        else
        {
            if(LevelData.levelData > levelNumber)
            LevelData.levelData++;
            LevelData.Save();
            Debug.Log("next level...");
            sceneLoader.LoadScene("Level" + (levelNumber+1).ToString());
        }
    }
}
