using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WinLoseStateManager : MonoBehaviour {
    [SerializeField]
    private Text conditionText;
    [SerializeField]
    private SceneLoader sceneLoader;
    [SerializeField]
    private TimeLeft timer;
    [SerializeField]
    private Score score;
    [SerializeField]
    private GameObject conditionHolder;
    void Start()
    {
        Time.timeScale = 1f;
        EventManager.OnHittingPlayer += Lost;
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

        timer.TimeScaling = 10f;
        conditionHolder.SetActive(true);
        conditionText.text = text;
        while (timer.TimeLimit > 0)
        {
            score.AddScore(1);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(duration);
        sceneLoader.LoadScene("Main");
    }
    public void RemoveDelegates()
    {

    }
}
