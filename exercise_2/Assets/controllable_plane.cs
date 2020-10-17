using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllable_plane : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    public Vector3 point; //position of the point you want to rotate around
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && player.GetComponent<gravity>().DistanceToPlane(transform.up) != 0)
        {
            transform.RotateAround(point, Vector3.forward, 20 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && player.GetComponent<gravity>().DistanceToPlane(transform.up) != 0)
            transform.RotateAround(point, -Vector3.forward, 20 * Time.deltaTime);

        if (Input.GetKey(KeyCode.S) && player.GetComponent<gravity>().DistanceToPlane(transform.up) != 0)
        {
            transform.RotateAround(point, Vector3.left, 20 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W) && player.GetComponent<gravity>().DistanceToPlane(transform.up) != 0)
            transform.RotateAround(point, -Vector3.left, 20 * Time.deltaTime);
    }
}
