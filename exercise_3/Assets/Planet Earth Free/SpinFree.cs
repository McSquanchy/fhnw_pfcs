using System.Collections;
using UnityEngine;

/// <summary>
/// Spin the object at a specified speed
/// </summary>
public class SpinFree : MonoBehaviour {
	[Tooltip("Spin: Yes or No")]
	public bool Spin;

	[Tooltip("Speed")]
	public int Speed = 500;

	[Tooltip("Radius of the circle")]
	public int Radius = 500;

	[Tooltip("Direction of motion")]
	public bool clockwise = true;

    [Tooltip("Number of Rotation around sphere's Y-axis")]
    public int Rotations = 3;

    private float Period;

    void Start()
    {
        Period = (2 * Radius * Mathf.PI) / Speed;
    }

    // Update is called once per frame
    void Update() {
        Period = (2 * Radius * Mathf.PI) / Speed; // Rotation Time
        float RotationPeriod = Period / Rotations; // Time to complete on rotation about itself

        float ac = Speed * Speed / Radius;
        Vector3 angularDirection = (new Vector3(0, 0, 0) - transform.position).normalized * ac; // Angular Acceleration Vector
        Vector3 velocityDirection = Quaternion.AngleAxis(clockwise ? -90 : +90, Vector3.up) * angularDirection; // Rotate 90deg to get Velocity

        transform.position = Vector3.ClampMagnitude(transform.position + velocityDirection.normalized* Speed * Time.deltaTime, Radius); // Clamp Magnitude to prevent increasing error and keep Radius fixed

        transform.Rotate(0, (360 / (RotationPeriod)) * Time.deltaTime, 0, Space.Self); // Rotate by increment
    }
}