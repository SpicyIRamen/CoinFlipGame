using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    
    void OnCollisionEnter (Collision col)
 {
     
     float velocity = 150;
     float force;
     if (col.gameObject.name == ("CustomCoin2"))
     {
         if (velocity >= 5)
         {
             force = 2000; //Hard
             Vector3 dir = col.contacts [0].point - transform.position;
             dir = -dir.normalized;
             col.gameObject.GetComponent<Rigidbody> ().AddForce (dir * force);
             Debug.Log ("hitcoin");
         }
     }
  
}
}

