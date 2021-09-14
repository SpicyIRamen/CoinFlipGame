using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    GameObject gObj = null;
    Plane objPlane;
    Vector3 m0;

    Ray GenerateMouseRay(Vector3 touchPos)
    {
        Vector3 mousePosFar = new Vector3(touchPos.x, touchPos.y, Camera.main.farClipPlane);

        Vector3 mousePosNear = new Vector3(touchPos.x, touchPos.y, Camera.main.farClipPlane);

        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        Ray mr = new Ray(mousePosN, mousePosF - mousePosN);
        return mr;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {       
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
            Ray mouseRay = GenerateMouseRay(Input.GetTouch(0).position);
            RaycastHit hit;

                if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
                {
                gObj = hit.transform.gameObject;
                objPlane = new Plane(Camera.main.transform.forward * -1, gObj.transform.position);

                //calulate touch offset
                Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                float rayDistane;
                objPlane.Raycast(mRay, out rayDistane);
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && gObj)
            {

            Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            float rayDistance;
            
            if (objPlane.Raycast(mRay, out rayDistance))
                gObj.transform.position = mRay.GetPoint(rayDistance) + m0;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended && gObj)
            {
            gObj = null;
            }
        }

    }
}
