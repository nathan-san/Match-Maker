using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {
    public static int levelData;
    public static float personalHighScore;
    public static int maxLevel = 5;
    void Start () {
        //ClearPlayerPrefs();
        Load();
        Save();
        
    }
    public static void Save()
    {
        PlayerPrefs.SetInt("leveldata", levelData);
    }
    public static void SaveHighScore(float value)
    {
        personalHighScore = value;
        PlayerPrefs.SetFloat("personalhighscore", value);
    }
    public static void Load()
    {
        if (!PlayerPrefs.HasKey("leveldata"))
        {
            PlayerPrefs.SetInt("leveldata", 1);
        }
        if (!PlayerPrefs.HasKey("personalhighscore"))
        {
            PlayerPrefs.SetInt("personalhighscore", 0);
        }

        personalHighScore = PlayerPrefs.GetFloat("personalhighscore");
        levelData = PlayerPrefs.GetInt("leveldata");
    }
    public static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
