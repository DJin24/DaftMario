using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private static Text display;
    private static int score = 0;
    internal void Start ()
    {
        display = GetComponent<Text>();
        Refresh();
    }

    public static void AddToScore()
    {
        score += 1;
        Refresh();
    }

    public static void ResetScore()
    {
        score = 0;
        Refresh();
    }
    
    private static void Refresh()
    {
        display.text = $"Score: {score}";
    }
}