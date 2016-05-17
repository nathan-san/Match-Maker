using UnityEngine;
using System.Collections;

public class ScoreData {
    public static float score = 3;

    public static void AddValue(float value)
    {
        score += value;
    }
    public static void SetValueZero()
    {
        score = 0;
    }
}
