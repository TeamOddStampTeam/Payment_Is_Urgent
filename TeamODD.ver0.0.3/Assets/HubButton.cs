using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HubButton : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject MatchLoading;

    void Start()
    {
        Canvas = GameObject.Find("GroupGameButton");
        MatchLoading = GameObject.Find("Matching");
    }


    public void PlayAutoMatch()
    {
        SceneManager.LoadScene("ServerWait");

        WTClient.PlayEnterServer = true;
    }
    public void JoinRoomToPlay()
    {
        //UnityEngine.Debug.Log("Join Room");
        SceneManager.LoadScene("GameLobby");
    }

    public void ShopStampSkins()
    {
        //UnityEngine.Debug.Log("Open Stamp");
        SceneManager.LoadScene("SampleScene");
    }
    public void ShopTableSkins()
    {
        //UnityEngine.Debug.Log("Open Table");
        SceneManager.LoadScene("SampleScene_T");
    }
    public void ShopInkSkins()
    {
        //UnityEngine.Debug.Log("Open Ink");
        SceneManager.LoadScene("SampleScene_I");
    }
    public void Options()
    {
        //UnityEngine.Debug.Log("Open Option");
        SaveData.RemakeDataInHub = true;
        SaveData.DoLoadData = true;
    }
    public void Custom()
    {
        SceneManager.LoadScene("MyStorage");
    }

    void Update()
    {
        
    }

    
}
