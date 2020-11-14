using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    private GameObject plane;
    private Vector3 steepestSlope, planeNormal, velocity, accel;
    private readonly Vector3 gravity = new Vector3(0, 9.8f, 0);
    private Rigidbody rb;
    private Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        steepestSlope = new Vector3(0f, 0f, 0f);
        rb = GameObject.Find("Cube").GetComponent<Rigidbody>();
        plane = GameObject.Find("Plane");
        velocity = new Vector3(0f, 0f, 0f);
        accel = new Vector3(0f, 0f, 0f);
        force = -gravity * rb.mass;
    }

    // Update is called once per frame
    void Update()
    {
        planeNormal = plane.transform.up;
        steepestSlope = new Vector3(planeNormal.x / planeNormal.y, -(planeNormal.x * planeNormal.x + planeNormal.z * planeNormal.z) / (planeNormal.y * planeNormal.y), planeNormal.z / planeNormal.y);

        //force = Vector3.Project(force, steepestSlope);
        //accel = force / rb.mass;
        //velocity += accel * Time.deltaTime;
        //transform.position += velocity * Time.deltaTime;
        //Debug.Log(vector3.project(force, steepestslope));
        //Debug.Log("Force: " + force);
        //Debug.Log("Steepest Slope: " + steepestSlope);
        //Debug.Log("Acceleration: " + accel);
        //Debug.Log("Velocity: " + velocity);

        rb.AddForce(Vector3.Project(force, steepestSlope));
        //transform.position += steepestSlope * Time.deltaTime;
    }
}
