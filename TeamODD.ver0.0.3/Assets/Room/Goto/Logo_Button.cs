using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo_Button : MonoBehaviour
{
    public void Goto_GameLobby()
    {
        SaveData.Loads();
        SceneManager.LoadScene("SampleScene");
    }

    public void Goto_GameTutorial()
    {
        SceneManager.LoadScene("IntroduceHowtoplay");
    }
}
