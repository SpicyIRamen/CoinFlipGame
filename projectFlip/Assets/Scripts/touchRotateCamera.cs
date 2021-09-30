using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchRotateCamera : MonoBehaviour
{
    public Camera MainCamera;
    TouchPhase touchPhase = TouchPhase.Moved;
    bool spinAround = false;
    public Transform target;
    public float orbitDistance = 10.0f, orbitDegreesPerSec = 180.0f, distance = 5.0f, maxDistance = 20, minDistance = .6f, currentDistance;
    public float xSpeed = 5.0f, ySpeed = 5.0f, moveSpeed = 0.017f, xDeg = 0.0f, yDeg = 0.0f;
    public int yMinLimit = -80, yMaxLimit = 80;
    private Quaternion currentRotation;
    private Quaternion desiredRotation;
    private Quaternion rotation;
    private Vector3 position;
    private bool enableTouch = true;
    public bool disableCamera = false;
    public Button confirmCamera;
    public int CoinFlipSound;
    
    public static touchRotateCamera instance;

    //public float waitToHit = 5f;

    [HideInInspector]
    public GameObject cameraPhase;
    [HideInInspector]
    public GameObject flipPhase;


    private void Awake(){
        instance = this;
    }

    void Start()
    {
        cameraPhase = GameObject.Find("cameraPhase");
        flipPhase = GameObject.Find("flipPhase");
        flipPhase.SetActive(false);
        Init();
    }

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
        if (TimerForCoin.instance.timeForCameraPhaseRanOut)
        {
            CoinSide.instance.afkSpin();
        }
        if (disableCamera == true)
        {
            RaycastScript();
        }
        cameraSpinAfterFlip();
    }

    //Camera logic on LateUpdate to only update after all character movement logic has been handled.

    void LateUpdate()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved && disableCamera == false)
        {
            Vector2 touchposition = Input.GetTouch(0).deltaPosition;
            xDeg += touchposition.x * xSpeed * 0.002f;
            yDeg -= touchposition.y * ySpeed * 0.002f;
            yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);

            Button btn = confirmCamera.GetComponent<Button>();
            btn.onClick.AddListener(ButtonClicked);
        }
        else
        {
            TimerForCoin.instance.timeScript();
        }
        if (spinAround == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 8, transform.position.z), Time.deltaTime * moveSpeed);
            transform.LookAt(target);
        }
        else
        {
            desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
            currentRotation = transform.rotation;
            rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime);
            transform.rotation = rotation;

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
        if (enableTouch == true)
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == touchPhase)
            {
                Ray ray2 = MainCamera.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                Debug.DrawRay(ray2.origin, ray2.direction * 100, Color.red, 100f);

                if (Physics.Raycast(ray2, out hit))
                {
                    //var Timer = waitToHit += Time.deltaTime;
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
                        flipPhase.SetActive(false);
                        var randomNumber = Random.Range(10f, 20f);
                        //rig.AddForceAtPosition(Vector3.up * randomNumber, hit.point, ForceMode.VelocityChange);
                        rig.AddForceAtPosition(Vector3.up * randomNumber, new Vector3(1, 9, 0), ForceMode.VelocityChange);
                        AudioManager.instance.PlaySfx(CoinFlipSound);
                        Debug.Log("Coin flip sound plays");
                        enableTouch = false;
                        rig.useGravity = true;
                        Debug.Log("Force is: " + randomNumber);
                        spinAround = true;
                    }
                }
            }
        }
    }

    public void cameraSpinAfterFlip()
    {
        if (spinAround == true)
        {
            transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
    }

    public void ButtonClicked()
    {
        // TimerForCoin.instance.timeScript();
        disableCamera = true;
        Debug.Log("Camera disabled");
        cameraPhase.SetActive(false);
        flipPhase.SetActive(true);
    }

    // public void addForce()
    // {
    //     flipPhase.SetActive(false);
    //     var randomNumber = Random.Range(10f, 20f);
    //     rig.AddForceAtPosition(Vector3.up * randomNumber, hit.point, ForceMode.VelocityChange);
    //     AudioManager.instance.PlaySfx(CoinFlipSound);
    //     Debug.Log("Coin flip sound plays");
    //     enableTouch = false;
    //     rig.useGravity = true;
    //     Debug.Log("Force is: " + randomNumber);

    //     spinAround = true;


    // }



}


