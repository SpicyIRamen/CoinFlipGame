using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevPreload : MonoBehaviour
{
    void Awake()
    {
        GameObject check = GameObject.Find("GameManager");
        GameObject check1 = GameObject.Find("PlayerManager");

        //GameObject playerHeads = GameObject.Find("PlayerHeads");
        //playerHeads.GetComponent<PlayerTurn>().enabled = true;
        //GameObject UIMenu = GameObject.Find("UI");

        //GameObject chooseCoin = GameObject.Find("ChooseCoin");
        //chooseCoin.SetActive(false);


        //chooseCoin.SetActive(false);


        // check.GetComponent<GameManager>().gameObject.SetActive; exempel
        if (check == null)
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
        }
    }
    //void Update()
    //{
    //    if (!chooseCoin)
    //    {
    //        if (timer > 0)
    //        {
    //            timer -= Time.deltaTime;
    //        }

    //        if (timer <= 0)
    //        {
    //            Debug.Log("ChooseCoin setActive");
    //            chooseCoin.SetActive(true);
    //        }
    //    }
    //}


}
