using UnityEngine;

public class GyroManager : MonoBehaviour
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

    private void Start()
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

    private void Update()
    {
        if (gyroActive)
        {
            rotation = gyro.attitude;
            //Debug.Log(rotation);
        }
        if (GetComponent<Rigidbody>().position.y >= 105.0)
        {
            gyro = Input.gyro;
            gyro.enabled = false;
            gyroActive = gyro.enabled;
        }
    }
    public Quaternion GetGyroRotation()
    {
        return rotation;
    }
}