using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerChild : MonoBehaviour
{
    public AudioClip flower_sound;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().PlayOneShot(flower_sound);
        }
    }
}
