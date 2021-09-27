using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantTorque : MonoBehaviour
{

    public Vector3 impulseMagnitude = new Vector3(0.0f, 5.0f, 0.0f);
    bool impulse_oneTime = true;

    public void ApplyInstantTorque()
    {
        if (impulse_oneTime)
        {
            GetComponent<Rigidbody>().AddForce(impulseMagnitude, ForceMode.Impulse);
            impulse_oneTime = false;
        }
    }
}
