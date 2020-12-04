using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public float amplitude = 1.0f;
    public float frequency = 1.0f;
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
        pos.y += amplitude * Mathf.Sin ((Time.time + delay) * frequency);
        transform.position = pos;
    }
}
