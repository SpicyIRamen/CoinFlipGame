using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCylinderCollision : MonoBehaviour
{
    


    public Transform CoinPlatform;

    void Start()
    {
        Transform cylinder = Instantiate(CoinPlatform) as Transform;
        Physics.IgnoreCollision(cylinder.GetComponent<Collider>(), GetComponent<Collider>());
    }
}
 







