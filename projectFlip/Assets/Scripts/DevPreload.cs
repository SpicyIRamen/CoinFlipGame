using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevPreload : MonoBehaviour
{
 
    void Awake()
    {
        GameObject check = GameObject.Find("GameManager");
       // check.GetComponent<GameManager>().gameObject.SetActive; exempel
        if (check == null)
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
        }
    }

    
}
