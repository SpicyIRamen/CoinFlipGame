using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TestSwipeDetector : MonoBehaviour
{
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;

    // Variables for controlling momentum of the coin
    public float Speed;
    public float AngularSpeed;
    protected Rigidbody r;

    public float SWIPE_THRESHOLD = 20f;

    void Start() {
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
            
        foreach (Touch touch in Input.touches)
        {
            print(touch.deltaPosition);
           
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
            }
        }
    }
    
    void checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeUp();

                // 4 next lines handles the angular momentum of the coin. 
                Speed = r.velocity.magnitude*100;
                AngularSpeed = r.velocity.magnitude;
                r.maxAngularVelocity = float.MaxValue;
                r.AddTorque(Vector3.forward);
            }
    
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    //////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////
    void OnSwipeUp()
    {
        // Debug.Log("Swipe UP");
    }
}
}
