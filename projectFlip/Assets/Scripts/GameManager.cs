using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action <GameState> OnGameStateChanged;

    void Awake(){
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.SelectCoinSide);
        
    }

    public void UpdateGameState(GameState newState){
        State = newState;

            switch (newState){

                case GameState.SelectCoinSide:
                    SelectCoinSide();
                    break;
                case GameState.Player1Turn: 
                    break;
                case GameState.Player2Turn: 
                    break;
                case GameState.ScoreUI:
                    break;
                default:
                        throw new ArgumentOutOfRangeException(nameof(newState), newState, null);    
            }   
            OnGameStateChanged?.Invoke(newState);

    }

    private void SelectCoinSide()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum GameState{
    SelectCoinSide,
    Player1Turn,
    Player2Turn,
    ScoreUI
}