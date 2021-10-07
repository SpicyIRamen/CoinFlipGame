using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSideRandomizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string randSide()
    {
        string[] coinSide = new string[] { "Heads", "Tails"};
        System.Random random = new System.Random();
        int useSide = random.Next (coinSide.Length);
        string pickSide = coinSide[useSide];
        Debug.Log (pickSide);
        Debug.Log("Ran randSide script");
        return pickSide;
    }
}
