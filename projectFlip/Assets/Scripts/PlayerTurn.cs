using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    public CoinSideRandomizer coinSideRandomizer;
    string pickSide;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player heads is active");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerChosenSide()
    {
        pickSide = this.coinSideRandomizer.randSide();
        Debug.Log("Player chosen side is" + pickSide);
    }

}
