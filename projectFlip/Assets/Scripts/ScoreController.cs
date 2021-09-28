using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    public GameObject scoreTextPlayer1;
    public GameObject scoreTextPlayer2;

    public int goalToWin = 2;

    // Update is called once per frame
    void Update()
    {
        if (this.scorePlayer1 >= this.goalToWin || this.scorePlayer2 >= this.goalToWin)
        {
            Debug.Log("Game Won");
        }
    }

    private void FixedUpdate()
    {
        Text P1Text = this.scoreTextPlayer1.GetComponent<Text>();
        P1Text.text = $"Player1: {this.scorePlayer1.ToString()}";

        Text P2Text = this.scoreTextPlayer2.GetComponent<Text>();
        P2Text.text = $"Player2: {this.scorePlayer2.ToString()}";
    }

    public void GoalPlayer1()
    {
        this.scorePlayer1++;
    }

    public void GoalPlayer2()
    {
        this.scorePlayer2++;
    }
}