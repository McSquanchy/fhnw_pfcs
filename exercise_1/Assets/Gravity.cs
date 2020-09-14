using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private const float GRAVITY = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {


        //update the position
        transform.position = transform.position + new Vector3(0, GRAVITY * Time.deltaTime, 0);

        ////output to log the position change
        //Debug.Log(transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit:" + other.name);
    }
}
