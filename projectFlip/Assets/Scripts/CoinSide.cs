using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSide : MonoBehaviour
{
    private bool isHeads = true;
    private float timeLeft = 10;
    private bool timer = false;

    public int CoinDropSound;
    public int ResultSound;
    public GameObject obj;
    private float x;

    public ScoreController scoreController;

    public Rigidbody rb;

    public static CoinSide instance;

    bool forceAdded = false;
    public Vector3 impulseMagnitude = new Vector3(0.0f, 5.0f, 0.0f);

    //Check if coin is Heads or Tails



    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();

        forceAdded = true;
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
               AudioManager.instance.PlaySfx(ResultSound);
                Debug.Log("Flawless Victory sound plays");
            }
       }

   }

    private void coinSideCheck()
    {
        x = obj.transform.eulerAngles.x;
        Debug.Log("x: " + x);


        if (x > 80 && x < 100)
        {
            isHeads = false;
            Debug.Log("Its tails");
            this.scoreController.GoalPlayer1();

        }
        else if (x > 260 && x < 280)
        {
            isHeads = true;
            Debug.Log("Its heads");
            this.scoreController.GoalPlayer2();

        }
        else
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
            AudioManager.instance.PlaySfx(CoinDropSound);
            Debug.Log("Coin drop sound plays");
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Collision with floor");
            timer = true;
        }
    }

    public void afkSpin()
    {
        if (forceAdded == true)
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
            GetComponent<Rigidbody>().AddForce(impulseMagnitude, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddTorque(0, 0, 5000);

            forceAdded = false;
            
            Debug.Log("Force addas...");
        }
    }
}


