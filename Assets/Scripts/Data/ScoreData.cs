using UnityEngine;
using System.Collections;

public class ScoreData : MonoBehaviour
{
    public static float score = 0;

    public static void AddValue(float value)
    {
        score += value;
    }
    public void SetValueZero()
    {
        score = 0;
    }
}
