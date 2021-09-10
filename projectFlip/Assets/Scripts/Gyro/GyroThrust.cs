using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroThrust : MonoBehaviour
{
    public Vector3 forceVec;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Input.gyro.userAcceleration.y * forceVec);
    }
}
