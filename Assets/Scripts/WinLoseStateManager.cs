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
    void Start()
    {
        //Time.timeScale = 1f;
        EventManager.OnHittingPlayer += Lost;
        EventManager.OnWinning += Win;
        StartCoroutine(Intro(2,0.001f));
    }
    private IEnumerator Intro(float duration, float timeScale)
    {
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

        timer.TimeScaling = 10;
        conditionHolder.SetActive(true);
        conditionText.text = text;
        while (timer.TimeLimit > 0)
        {
            score.AddScore(10);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(duration);
        if(levelNumber >= levelCount)
        {
            conditionText.fontSize = 60;
            conditionText.text = "you have beaten \n the game!";
            Debug.Log("you have beaten the game!");
        }
        else
        {
            Debug.Log("next level...");
            sceneLoader.LoadScene("Level" + (levelNumber+1).ToString());
        }
    }
}
