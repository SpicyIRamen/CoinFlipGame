using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManagerInvisObjectTriggerCoin : MonoBehaviour
{

    #region Instance
    private static GyroManager instance;
    public static GyroManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned GyroManager", typeof(GyroManager)).GetComponent<GyroManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    [Header("Logic")]
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroActive;

    public InstantTorque instantTorque;
    bool debugged = false;

    // Start is called before the first frame update
    void Start()
    {
        GyroManager.Instance.EnableGyro();
    }

    public void EnableGyro()
    {
        if (gyroActive)
            return;

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroActive = gyro.enabled;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroActive)
        {
            rotation = gyro.attitude;
        }
        if (GetComponent<Rigidbody>().position.y >= 25)
        {
            gyro = Input.gyro;
            gyro.enabled = false;
            gyroActive = gyro.enabled;
            instantTorque.ApplyInstantTorque();            
        } 
        DebugHeight();
    }

    public void DebugHeight()
    {
        if (GetComponent<Rigidbody>().position.y < 25 && GetComponent<Rigidbody>().position.y > 5 && !debugged)
        {
            Debug.Log("Swipe Harder");
            debugged = true;        
        }
    }

    public Quaternion GetGyroRotation()
    {
        return rotation;
    }
}

