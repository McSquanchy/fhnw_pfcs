using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllable_plane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector3 point; //position of the point you want to rotate around
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(point, Vector3.forward, 20 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
            transform.RotateAround(point, -Vector3.forward, 20 * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
        {
            transform.RotateAround(point, Vector3.left, 20 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
            transform.RotateAround(point, -Vector3.left, 20 * Time.deltaTime);
    }
}
