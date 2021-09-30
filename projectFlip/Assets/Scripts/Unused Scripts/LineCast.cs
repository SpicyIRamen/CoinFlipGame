//using UnityEngine;
//using System.Collections;

//public class LineCast : MonoBehaviour
//{
//    public Transform target;
//    public Rigidbody rb;

//    void Update()
//    {


//        if (Physics.Linecast(transform.position, target.position))
//        {
//            //rb.AddForceAtPosition(transform.position * 50f, target.position, ForceMode.VelocityChange);
//            rb.AddForceAtPosition(target.position * 50f, ForceMode.VelocityChange);
//            Debug.Log("blocked");
//        }
//    }
//}