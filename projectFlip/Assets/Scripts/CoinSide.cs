using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class CoinSide : MonoBehaviour
//{

//    bool isHeads = true;
//    float timeLeft = 5;
//    bool timer = false;

//    private void headCheck()
//    {
//        var x = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).x;
//        Debug.Log("x: " + x);


//        if (x > 80 && x < 100 )
//        {
//             isHeads = false;
//             Debug.Log("Its tails");
             

//        }else if (x < -80 && x > -100f)
//        {
//             isHeads = true;
//             Debug.Log("Its heads");
            

//        }else
//        {
//            Debug.Log("No value");
//        }


//    }

//    // private void timeCheck()
//    // {
//    //     while (timer == true)
//    //     {
//    //           if ( timeLeft > 0 )
//    //             {
//    //                 timeLeft -= Time.deltaTime;
//    //                 Debug.Log(timeLeft + "IF");
//    //             }else
//    //             {
//    //                 Debug.Log("Time has run out");
//    //                 timeLeft = 0;
//    //                 headCheck();
//    //                 Debug.Log(timeLeft + "Else");
//    //                 timer = false;
//    //             }
//    //     }
               
//    // }

//    //Detect collisions between the GameObjects with Colliders attached
//    private void OnCollisionEnter(Collision collision)
//    {
        
//        //Check for a match with the specified name on any GameObject that collides with your GameObject
//        if (collision.gameObject.name == "Floor")
//            {
//                //If the GameObject's name matches the one you suggest, output this message in the console
//                Debug.Log("Collision with floor");
//                timer = true;
//                //timeCheck();
//                // timeLeft -= Time.deltaTime;
//                // Debug.Log(timeLeft);
//                // if ( timeLeft <= 1.0f )
//                // {
//                //     Debug.Log("Time has run out");
//                //     headCheck();
//                // }
//            }
//    }

//    void Start() 
//    {
    
//    }


//    // Update is called once per frame
//    void Update()
//    {
//        if (timer)
//        {
//            if (timeLeft > 0)
//            {
//                timeLeft -= Time.deltaTime;
//            }
//            else
//            {
//                Debug.Log("Time has run out!");
//                timeLeft = 0;
//                timer = false;
//                headCheck();
//            }
//        }

//    }
//}
