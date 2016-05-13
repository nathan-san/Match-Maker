using UnityEngine;
using System.Collections;

public class EventManager {
    public delegate void BallIsHitted(float value);
    public static event BallIsHitted OnDamage;

    public delegate void SmallBallDestroyed();
    public static event SmallBallDestroyed OnDisappearing;

    public delegate void BallHitsPlayer(float timeScale, float duration, string text);
    public static event BallHitsPlayer OnHittingPlayer;

    public delegate void PlayerWins(float duration, string text);
    public static event PlayerWins OnWinning;

    public static void Nullify()
    {
        OnDamage = null;
        OnDisappearing = null;
        OnHittingPlayer = null;
        OnWinning = null;
    }
    public static void Damage(float value)
    {
        OnDamage(value);
    }
    public static void HittingPlayer(float timeScale, float duration, string text)
    {
        OnHittingPlayer(timeScale, duration, text);
    }
    public static void Count()
    {
        OnDisappearing();
    }
    public static void Win(float duration, string text)
    {
        OnWinning(duration, text);
    }
}
