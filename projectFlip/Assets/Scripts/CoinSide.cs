using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSide : MonoBehaviour
{
  private bool isHeads = true;
  private float timeLeft = 10;
  private bool timer = false;

   public GameObject obj;
   private float x;

    //Check if coin is Heads or Tails
   private void coinSideCheck()
   {    
       x = obj.transform.eulerAngles.x;
       Debug.Log("x: " + x);
         

       if (x > 80 && x < 100 )
       {
            isHeads = false;
            Debug.Log("Its tails");
             

       }else if (x > 260 && x < 280)
       {
            isHeads = true;
            Debug.Log("Its heads");
            

       }else
       {
           Debug.Log("No value");
       }
   }

   

   //Detect collisions between the GameObjects with Colliders attached
   private void OnCollisionEnter(Collision collision)
   {
        
       //Check for a match with the specified name on any GameObject that collides with your GameObject
       if (collision.gameObject.tag == "Objects")
           {
               //If the GameObject's name matches the one you suggest, output this message in the console
               Debug.Log("Collision with floor");
               timer = true;
               
           }
   }

 


   // Update is called once per frame
   void Update()
   {
       if (timer)
       {
           if (timeLeft > 0)
           {
               timeLeft -= Time.deltaTime;
           }
           else
           {
               Debug.Log("Time has run out!");
               timeLeft = 0;
               timer = false;
               coinSideCheck();
           }
       }

   }
}
