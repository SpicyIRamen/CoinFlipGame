using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCoinScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //       #pragma strict
        //var topdownCam : GameObject;

        //private var cameraFollow: CameraFollow;
        //private var planeSelfMove: PlaneSelfMove;

        //function Start () {

        //     cameraFollow = topdownCam.GetComponent(CameraFollow);
        //     planeSelfMove = GetComponent(PlaneSelfMove);

        //}

        //function OnTriggerEnter (collider : Collider) {

        //     if (collider.game object.tag == "SpawntriggerStopCamera") {
        //          cameraFollow.enabled = false;
        //          planeSelfMove.enabled = false;
        //     }
        //}
        //   private var coinScript;

        //   void onCollisionEnter(Collision collision)
        //   {
        //       if(collision.gameObject.name == "StopCoinScriptObject")
        //       {
        //           GetComponent(RaycastTest).enabled = false;
        //       }
        //   }

        // Update is called once per frame
        void Update()
        {
            if (GetComponent<Rigidbody>().position.y >= 100.0)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                Debug.Log("max height reached");
            }
        }
    }
}
