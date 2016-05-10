using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WinLoseStateManager : MonoBehaviour {
    [SerializeField]
    private Text conditionText;
    [SerializeField]
    private SceneLoader sceneLoader;
    void Start()
    {
        
        //Win();
    }
    public void Lost(float timeScale, float duration,string text)
    {
        StartCoroutine(Losing(timeScale, duration, text));
    }
    IEnumerator Losing(float timeScale, float duration, string text)
    {
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
        conditionText.text = text;
        yield return new WaitForSeconds(duration);
        sceneLoader.LoadScene("Main");
    }

}
