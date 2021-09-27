using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCamera : MonoBehaviour
{
    // STATE
    private float _initialYAngle = 1000f;
    private float _appliedGyroYAngle = 1000f;
    private float _calibrationYAngle = 1000f;
    private Transform _rawGyroRotation;
    private float _tempSmoothing;

    public Transform targetObject;
    private Vector3 initalOffset;
    private Vector3 cameraPosition;

    public Transform target;
    private Vector3 offset;
    public Transform target2;

    // SETTINGS
    [SerializeField] private float _smoothing = 0.1f;

    private IEnumerator Start()
    {
        Input.gyro.enabled = true;
        Application.targetFrameRate = 60;
        _initialYAngle = transform.eulerAngles.x;

        _rawGyroRotation = new GameObject("CustomCoin2").transform;
        _rawGyroRotation.position = transform.position;
        _rawGyroRotation.rotation = transform.rotation;

        // Wait until gyro is active, then calibrate to reset starting rotation.
        yield return new WaitForSeconds(1);

        StartCoroutine(CalibrateYAngle());

        //initalOffset = transform.position - targetObject.position;
        //offset = transform.position - target.position + new Vector3(0, 2, 10);
    }

    private void Awake()
    {
        offset = transform.position - target.position + new Vector3(0, 2, 10);
    }

    private void Update()
    {
        ApplyGyroRotation();
        ApplyCalibration();

        transform.rotation = Quaternion.Slerp(transform.rotation, _rawGyroRotation.rotation, _smoothing);
    }

    private void LateUpdate()
    {

        //cameraPosition = targetObject.position - initalOffset;
        //transform.position = cameraPosition;
        transform.position = target.position + offset;

        transform.LookAt(target2);
        transform.Translate(Vector3.right * Time.deltaTime);
    }

    private IEnumerator CalibrateYAngle()
    {
        _tempSmoothing = _smoothing;
        _smoothing = 1;
        _calibrationYAngle = _appliedGyroYAngle - _initialYAngle; // Offsets the y angle in case it wasn't 0 at edit time.
        yield return null;
        _smoothing = _tempSmoothing;
    }

    private void ApplyGyroRotation()
    {
        _rawGyroRotation.rotation = Input.gyro.attitude;
        _rawGyroRotation.Rotate(0f, 0f, 180f, Space.Self); // Swap "handedness" of quaternion from gyro.
        _rawGyroRotation.Rotate(90f, 180f, 0f, Space.World); // Rotate to make sense as a camera pointing out the back of your device.
        _appliedGyroYAngle = _rawGyroRotation.eulerAngles.y; // Save the angle around y axis for use in calibration.
    }

    private void ApplyCalibration()
    {
        _rawGyroRotation.Rotate(0f, -_calibrationYAngle, 0f, Space.World); // Rotates y angle back however much it deviated when calibrationYAngle was saved.
    }

    public void SetEnabled(bool value)
    {
        enabled = true;
        StartCoroutine(CalibrateYAngle());
    }
}
