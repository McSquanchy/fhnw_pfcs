using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private float v = 0.0f;
    private Vector3 v3Pos;
    private const float g = 9.80665f;

    void Start()
    {
        v3Pos = transform.position;
    }

    // deltaY = Vprev*t - 1/2*g*(t*t)
    // deltaV = -g*t

    void Update()
    {
        float t = Time.deltaTime;
        float delta = v * t  - g * t * t * 0.5f;

   
        v = v + g * t;
        Debug.Log(v);
        v3Pos.y -= delta;

        transform.position = v3Pos;

    }

    private void OnTriggerEnter(Collider other)
    {
        v *= -1;
    }
}