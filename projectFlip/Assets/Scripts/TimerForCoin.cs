using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerForCoin : MonoBehaviour
{
    public static TimerForCoin instance;
    public float timeRemaining = 5f;
    public bool timerIsRunning = false;
    public bool timeForCameraPhaseRanOut = false;
    public bool timeForFlipPhaseRanOut = false;

    public bool scriptActive;
    public GameObject GO;

    public Button confirmCamera;

    private void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        Button btn = confirmCamera.GetComponent<Button>();
        btn.onClick.AddListener(ButtonClicked);
    }
    void ButtonClicked(){

        timerIsRunning = false;
        timeRemaining = 0;
        Debug.Log("User pressed button");
        touchRotateCamera.instance.disableCamera = true;
        Debug.Log("Camera disabled from timeforcoinscript");
        touchRotateCamera.instance.cameraPhase.SetActive(false);
        touchRotateCamera.instance.flipPhase.SetActive(true);

        timeResetForFlipPhase();
        Debug.Log("Timer should reset");
    }

    void ButtonWasNotClicked()
    {
        timerIsRunning = false;
        timeRemaining = 0;
        touchRotateCamera.instance.disableCamera = true;
        Debug.Log("Camera disabled from timeforcoinscript");
        touchRotateCamera.instance.cameraPhase.SetActive(false);
        touchRotateCamera.instance.flipPhase.SetActive(true);

        timeResetForFlipPhase();
        timeForCameraPhaseRanOut = true;
        Debug.Log("Timer should reset");
    }

    // Den vill inte gå vidare till swipe phase.

    // Update is called once per frame
    public void Update()
    {       
        if (timerIsRunning)
         {
            if (timeRemaining > 0 && timerIsRunning == true)
            {
                timeRemaining -= Time.deltaTime;       
            }
            if (timeRemaining <= 0)
            {
                ButtonWasNotClicked();
            }
        }


    }

     public void timeScript(){

         if (scriptActive == false){
             GO.GetComponent<TimerForCoin>().enabled = true;
             touchRotateCamera.instance.RaycastScript();
         }
  
    }
    public void timeResetForFlipPhase()
    {
        timerIsRunning = true;
        timeRemaining = 5f;
    }
}
