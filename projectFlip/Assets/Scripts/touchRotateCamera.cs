using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchRotateCamera : MonoBehaviour
{
    public Camera MainCamera;
    TouchPhase touchPhase = TouchPhase.Ended;
    public Material hitMaterial;
    bool spinAround = false;

    public float orbitDistance = 10.0f;
    public float orbitDegreesPerSec = 180.0f;

    public Transform target;
    //public Vector3 targetOffset;
    public float distance = 5.0f;
    public float maxDistance = 20;
    public float minDistance = .6f;
    public float xSpeed = 5.0f;
    public float ySpeed = 5.0f;
    public int yMinLimit = -80;
    public int yMaxLimit = 80;
    //public float zoomRate = 10.0f;
    //public float panSpeed = 0.3f;
    //public float zoomDampening = 5.0f;

    private float xDeg = 0.0f;
    private float yDeg = 0.0f;
    private float currentDistance;
    private float desiredDistance;
    private Quaternion currentRotation;
    private Quaternion desiredRotation;
    private Quaternion rotation;
    private Vector3 position;

    private Vector3 FirstPosition;
    private Vector3 SecondPosition;
    private Vector3 delta;
    private Vector3 lastOffset;
    private Vector3 lastOffsettemp;
    //private Vector3 CameraPosition;
    //private Vector3 Targetposition;
    //private Vector3 MoveDistance;


    void Start() { Init(); }
    void OnEnable() { Init(); }

    public void Init()
    {
        //If there is no target, create a temporary target at 'distance' from the cameras current viewpoint
        if (!target)
        {
            GameObject go = new GameObject("CustomCoin2");
            go.transform.position = transform.position + (transform.forward * distance);
            target = go.transform;
        }

        distance = Vector3.Distance(transform.position, target.position);
        currentDistance = distance;
        desiredDistance = distance;

        //be sure to grab the current rotations as starting points.
        position = transform.position;
        rotation = transform.rotation;
        currentRotation = transform.rotation;
        desiredRotation = transform.rotation;

        xDeg = Vector3.Angle(Vector3.right, transform.right);
        yDeg = Vector3.Angle(Vector3.up, transform.up);
    }

    private void Update()
    {
        RaycastScript();
        booleanCheck();
    }

    /*
      * Camera logic on LateUpdate to only update after all character movement logic has been handled.
      */
    void LateUpdate()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchposition = Input.GetTouch(0).deltaPosition;
            xDeg += touchposition.x * xSpeed * 0.002f;
            yDeg -= touchposition.y * ySpeed * 0.002f;
            yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);

        }
        if (spinAround == true)
        {

            //transform.position = target.position + (transform.position - target.position).normalized * orbitDistance;

            //transform.RotateAround(target.position, Vector3.up, orbitDegreesPerSec * Time.deltaTime);

            transform.position = new Vector3(0, 5, 0);
            transform.LookAt(target);
            //transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
            Debug.Log("Should be spinning");
        } 
        else { 

        desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
        currentRotation = transform.rotation;
        rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime);
        transform.rotation = rotation;

        ////////Orbit Position

        // affect the desired Zoom distance if we roll the scrollwheel
        //desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);
        //currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime);


        position = target.position - (rotation * Vector3.forward * currentDistance);

        transform.position = position;
        }
    }
    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }


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

                    spinAround = true;

                }
            }
        }
    }
    public void booleanCheck()
    {
        if (spinAround == true)
        {
            transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
            Debug.Log("Should be spinning");
        }
    }
}