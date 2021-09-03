using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    Vector3 touchPosWorld;
    TouchPhase touchPhase = TouchPhase.Ended;

    public Material hitMaterial;
    // Start is called before the first frame update
    //void Start()
    //{
    
    //}
        // Update is called once per frame
        void Update()
        {

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == touchPhase)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 100f);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null)
                {

                    GameObject touchedObject = hit.transform.gameObject;

                    Debug.Log("Touched " + touchedObject.transform.name);
                }

                var rig = hit.collider.GetComponent<Rigidbody>();
                if (rig != null)
                {
                    rig.GetComponent<MeshRenderer>().material = hitMaterial;
                    rig.AddForceAtPosition(ray.direction * 50f, hit.point, ForceMode.VelocityChange);
                }
            }
        }
    }
    
}