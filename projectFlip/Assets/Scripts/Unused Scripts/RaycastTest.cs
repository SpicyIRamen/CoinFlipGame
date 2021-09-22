using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    public Camera MainCamera;
    //public Camera MainCamera;
    Vector3 touchPosWorld;
    TouchPhase touchPhase = TouchPhase.Ended;
    public Material hitMaterial;

    public static RaycastTest instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
    }

    // Disables gravity on all rigidbodies entering this collider.

        // Update is called once per frame
        void Update()
        {

        //if (Input.touchCount == 1 && Input.GetTouch(0).phase == touchPhase){
        //    Ray ray1 = MainCamera.ScreenPointToRay(Input.GetTouch(0).position);
        //    RaycastHit hit;
        //    Debug.DrawRay(ray1.origin, ray1.direction * 100, Color.green, 100f);
        //    if (Physics.Raycast(ray1, out hit))
        //    {
        //        Debug.Log(hit.transform.name);
        //        if (hit.collider != null)
        //        {
        //            GameObject touchedObject = hit.transform.gameObject;

        //            Debug.Log("Touched By Main Cam" + touchedObject.transform.name);
        //            Debug.Log(hit.point);
        //        }

        //    }
        //}

        RaycastScript();
        // if (Physics.Linecast(gameObject.transform.position, CustomCoin2.transform.position))
        // {
        //     Debug.Log("tocuhed to the sky...");

        // }

    }

    // public GameObject CustomCoin2;
    public void RaycastScript()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == touchPhase)
        {
            Ray ray2 = MainCamera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Debug.DrawRay(ray2.origin, ray2.direction * 100, Color.red, 100f);
            if (Physics.Raycast(ray2, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null)
                {

                    GameObject touchedObject = hit.transform.gameObject;

                    Debug.Log("Touched " + touchedObject.transform.name);
                    Debug.Log(hit.point);
                }

                var rig = hit.collider.GetComponent<Rigidbody>();
                if (rig != null)
                {
                    var randomNumber = Random.Range(10f, 20f);
                    rig.GetComponent<MeshRenderer>().material = hitMaterial;
                    rig.AddForceAtPosition(Vector3.up * randomNumber, hit.point, ForceMode.VelocityChange);
                    rig.useGravity = true;
                    Debug.Log("Force is: " + randomNumber);
                }
            }
        }
    }
}