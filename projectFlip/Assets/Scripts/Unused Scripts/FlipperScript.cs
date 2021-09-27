using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetFlipperToTouch();
    }

    private void SetFlipperToTouch(){
        var touchPos = Input.mousePosition;
        touchPos.z = 15; //distance of 10 units from camera

        rb.position = Camera.main.ScreenToWorldPoint(touchPos);
    }
}
