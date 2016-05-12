using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void PauseScene()
    {
        Time.timeScale = 0f;
    }

    public void PlayScene()
    {
        Time.timeScale = 1f;
    }
    
}
