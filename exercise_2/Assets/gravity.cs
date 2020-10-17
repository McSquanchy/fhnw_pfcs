using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    private Vector3 v3Pos;
    private Vector3 v3Vel;
    private GameObject plane;
    private readonly Vector3 v3G = new Vector3(0.0f, 9.80665f, 0.0f);

    void Start()
    {
        v3Pos = transform.position;
        v3Vel = new Vector3(0.0f, 0.0f, 0.0f);
        plane = GameObject.Find("Plane_Controllable");
    }

    // deltaY = Vprev*t - 1/2*g*(t*t)
    // deltaV = -g*t

    void Update()
    {

        Vector3 planeNormal = plane.transform.up;
        float t = Time.deltaTime;
        Vector3 delta = v3Vel * t - v3G * t * t * 0.5f;

        v3Vel = v3Vel + v3G * t;
        v3Pos -= delta;

        transform.position = v3Pos;

     

        if (DistanceToPlane(planeNormal) == 0)
        {
            float factor = -2F * Vector3.Dot(v3Vel, planeNormal);
            v3Vel = new Vector3(factor * planeNormal.x + v3Vel.x,
                factor * planeNormal.y + v3Vel.y,
                factor * planeNormal.z + v3Vel.z);
        }
    }

    public float DistanceToPlane(Vector3 inNormal)
    {
        float planeNormalizeFactor = (1 / Mathf.Sqrt(inNormal.x * inNormal.x + inNormal.y * inNormal.y + inNormal.z * inNormal.z));
        float planeEquationValue = Mathf.Abs(inNormal.x * transform.position.x + inNormal.y * transform.position.y + inNormal.z * transform.position.z);
        return Mathf.Round(planeNormalizeFactor * planeEquationValue);
    }
}
