using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public AudioClip goomba_sound;
    public float amplitude = 1f;
    public float frequency = 1f;
    private float delay;
    private Vector3 startPos;
    
    void Start()
    {
        delay = Random.Range(0f, 20f);
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 pos = startPos;
        pos.x += amplitude * Mathf.Sin ((Time.time + delay) * frequency);
        transform.position = pos;
    }
}
