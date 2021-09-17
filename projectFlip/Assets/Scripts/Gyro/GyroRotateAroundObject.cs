using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRotateAroundObject : MonoBehaviour
{
    private Gyroscope gyro;
    private bool gyroSupported;
    private Quaternion rotFix;

    //[SerializeField]
    //private Transform worldObj;
    //private float startY;

    [SerializeField]
    private float _gyroSensitivity = 3.0f;

    private float _rotationY;
    private float _rotationX;
    private float _rotationZ;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _distanceFromTarget = 3.0f;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    [SerializeField]
    private float _smoothTime = 0.2f;

    [SerializeField]
    private Vector3 _rotationXMinMax = new Vector2(-40, 40);

    void Start()
    {
        gyroSupported = SystemInfo.supportsGyroscope;

        //GameObject camParent = new GameObject("CustomCoin2");
        //camParent.transform.position = transform.position;
        //transform.parent = camParent.transform;

        if (gyroSupported)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            //camParent.transform.rotation = Quaternion.Euler(90f, 180f, 0f);
            //rotFix = new Quaternion(0, 0, 1, 0);
        }
    }

    void Update()
    {
        rotFix = new Quaternion(gyro.attitude.x, gyro.attitude.y, gyro.attitude.z, gyro.attitude.w);

        float RotationX = rotFix.x;
        float RotationY = rotFix.y;
        //float RotationZ = rotFix.z;

        //float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        //float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _rotationY += RotationX * _gyroSensitivity;
        _rotationX += RotationY * _gyroSensitivity;
        //_rotationZ += RotationZ;

        // Apply clamping for x rotation 
        _rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);

        // Apply damping between rotation changes
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;

        // Substract forward vector of the GameObject to point its forward vector to the target
        transform.position = _target.position - transform.forward * _distanceFromTarget;
    }
}