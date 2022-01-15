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
        SoundManager.soundManager.ButtonChoicePlaySound();
        SceneManager.LoadScene("ServerWait");

        WTClient.PlayEnterServer = true;
    }
    public void JoinRoomToPlay()
    {
        SoundManager.soundManager.ButtonChoicePlaySound();
        //UnityEngine.Debug.Log("Join Room");
        //SceneManager.LoadScene("GameLobby");
        SceneManager.LoadScene("GamePlayScene");
    }

    public void ShopStampSkins()
    {
        SoundManager.soundManager.ButtonChoicePlaySound();
        //UnityEngine.Debug.Log("Open Stamp");
        SceneManager.LoadScene("SampleScene");
    }
    public void ShopTableSkins()
    {
        SoundManager.soundManager.ButtonChoicePlaySound();
        //UnityEngine.Debug.Log("Open Table");
        SceneManager.LoadScene("SampleScene_T");
    }
    public void ShopInkSkins()
    {
        SoundManager.soundManager.ButtonChoicePlaySound();
        //UnityEngine.Debug.Log("Open Ink");
        SceneManager.LoadScene("SampleScene_I");
    }
    public void Options()
    {
        SoundManager.soundManager.ButtonChoicePlaySound();
        //UnityEngine.Debug.Log("Open Option");
        SaveData.RemakeDataInHub = true;
        SaveData.DoLoadData = true;
    }
    public void Custom()
    {
        //SceneManager.LoadScene("MyStorage");
    }

    void Update()
    {
        
    }

    
}
