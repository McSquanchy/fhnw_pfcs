using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private Vector3 v3Pos;
    private Vector3 v3Vel;
    private GameObject plane;
    private readonly Vector3 v3G = new Vector3(0.0f, 9.80665f, 0.0f);

    void Start()
    {
        v3Pos = transform.position;
        v3Vel = new Vector3(0.0f, 0.0f, 0.0f);
        plane = GameObject.Find("Player");
    }

    // deltaY = Vprev*t - 1/2*g*(t*t)
    // deltaV = -g*t

    void Update()
    {

        Vector3 planeNormal = plane.transform.up;
        float t = Time.deltaTime;
        Vector3 delta = v3Vel * t - v3G * t * t * 0.5f;

        v3Vel += v3G * t;
        v3Pos -= delta;

        transform.position = v3Pos;

     

        if (DistanceToPlane(planeNormal) < transform.GetComponentInParent<SphereCollider>().radius) // Calculate Distance
        {
            v3Vel = -2f * Vector3.Dot(v3Vel, planeNormal) * planeNormal + v3Vel;
        }
    }

    public float DistanceToPlane(Vector3 inNormal)
    {
        return Mathf.Round(Mathf.Abs(Vector3.Dot(inNormal, transform.position)) * inNormal.magnitude);
    }
}
