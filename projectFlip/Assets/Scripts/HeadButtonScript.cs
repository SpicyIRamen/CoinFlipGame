using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeadButtonScript : MonoBehaviour
{

	void Start()
	{
		//Button btn = headButton.GetComponent<Button>();
		//btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
		GameObject chooseCoin = GameObject.Find("ChooseCoin");
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