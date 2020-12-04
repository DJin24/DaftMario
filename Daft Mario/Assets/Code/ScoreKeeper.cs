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
        if (score >= 5) { Win(); }
        else { Refresh(); }
    }

    public static void ResetScore()
    {
        score = 0;
        Refresh();
    }

    public static void Win()
    {
        display.text = "You win! Press ESC to reset.";
        Time.timeScale = 0f;
    }
    
    public static void Lose()
    {
        display.text = "You died. Press ESC to reset.";
        Time.timeScale = 0f;
    }
    
    private static void Refresh()
    {
        display.text = $"Score: {score}";
    }
}