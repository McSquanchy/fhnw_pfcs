using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    private float v = 0.0f;
    private Vector3 v3Pos;
    private Vector3 v3Vel;
    private const float g = 9.80665f;
    private Vector3 v3G = new Vector3(0.0f, 9.80665f, 0.0f);

    void Start()
    {
        v3Pos = transform.position;
        v3Vel = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // deltaY = Vprev*t - 1/2*g*(t*t)
    // deltaV = -g*t

    void Update()
    {
        float t = Time.deltaTime;
        Vector3 delta = v3Vel * t - v3G * t * t * 0.5f;
        v3Vel = v3Vel + v3G * t;
        v3Pos -= delta;
        transform.position = v3Pos;

    }

    private void OnCollisionEnter(Collision collision)
    {
        v3Vel = Vector3.Reflect(v3Vel, collision.contacts[0].normal);
        Debug.Log(collision.contacts[0].normal);
    }

}
