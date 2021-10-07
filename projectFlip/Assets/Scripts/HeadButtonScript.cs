using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeadButtonScript : MonoBehaviour
{
	public CoinSideRandomizer coinSideRandomizer;
	public PlayerTurn playerTurn;
	void Start()
	{
		//Button btn = headButton.GetComponent<Button>();
		//btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
		GameObject chooseCoin = GameObject.Find("ChooseCoin");
		//CoinSideRandomizer.instance.randSide();
		this.coinSideRandomizer.randSide();
		this.playerTurn.playerChosenSide();
		chooseCoin.SetActive(false);
	}

	//public void TaskOnTouch()
 //   {
 //       if (Input.touchCount > 0)
	//	{
	//		Touch touch = Input.GetTouch(0);
	//		Debug.Log("Touched screen");
	//		TaskOnClick();
	//	}

	//}
    void Update()
    {

	}
}