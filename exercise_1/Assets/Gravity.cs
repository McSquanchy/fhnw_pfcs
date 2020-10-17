using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private GameObject plane;
    private Vector3 v3Pos;
    private float v = 0.0f;
    private const float g = 9.80665f;

    [Tooltip("Initial Y-Coordinate of the sphere.")]
    public int startingHeight = 50;

    void Start()
    {
        v3Pos = transform.position;
        plane = GameObject.Find("Plane");
        transform.position = new Vector3(0, startingHeight, 0);
    }

    // deltaY = Vprev*t - 1/2*g*(t*t)
    // deltaV = -g*t

    void Update()
    {
        float t = Time.deltaTime;
        v += g * t;
        float delta = v * t  - g * t * t * 0.5f;

        Debug.Log(v);

        v3Pos.y -= delta;
        transform.position = v3Pos;

        if (transform.position.y <= plane.transform.position.y) // detect collision
        {
            v *= -1; // flip direction to make sphere "bounce off"
        }
    }
}