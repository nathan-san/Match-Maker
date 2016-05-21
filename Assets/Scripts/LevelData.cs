using UnityEngine;
using System.Collections;

public class LevelData : MonoBehaviour {
    public static int levelData;
    public static int maxLevel = 2;
    void Start () {
        //ClearPlayerPrefs();
        Load();
        Save();
    }
    public static void Save()
    {
        PlayerPrefs.SetInt("leveldata", levelData);
    }

    public static void Load()
    {
        if(!PlayerPrefs.HasKey("leveldata"))
        {
            PlayerPrefs.SetInt("leveldata", 1);
        }
        levelData = PlayerPrefs.GetInt("leveldata");
    }
    public static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
