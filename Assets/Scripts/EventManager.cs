using UnityEngine;
using System.Collections;

public class EventManager {
    public delegate void DamageAction(float value);
    public static event DamageAction OnDamage;

    public delegate void CountAction();
    public static event CountAction OnDisappearing;

    public delegate void HitPlayer(float timeScale, float duration, string text);
    public static event HitPlayer OnHittingPlayer;

    public static void Nullify()
    {
        OnDamage = null;
        OnDisappearing = null;
        OnHittingPlayer = null;
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
}
