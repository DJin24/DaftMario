using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    private static Text scoreText; // everyone has the same text

    // Use this for initialization
    internal void Start ()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = String.Format("");
    }

    public static void Win()
    {
        scoreText.text = String.Format("You win! Press ESC to reset");
        Time.timeScale = 0;
    }
    
    public static void Lose()
    {
        scoreText.text = String.Format("You lose! Press ESC to reset");
        Time.timeScale = 0;
    }
}
