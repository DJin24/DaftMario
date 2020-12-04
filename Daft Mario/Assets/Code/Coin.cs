using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource audio_source;
    public AudioClip collect_sound;
    
    void Start()
    {
        audio_source = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audio_source.PlayOneShot(collect_sound);
            ScoreKeeper.AddToScore();
            Destroy(gameObject);
        }
    }
}
