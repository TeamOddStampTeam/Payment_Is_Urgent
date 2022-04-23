using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo_Button : MonoBehaviour
{
    public GameObject IBM;

    public void Awake()
    {
        IBM.SetActive(false);
    }

    public void Goto_GameLobby()
    {

        SaveData.Loads();

        if (SaveData.Check_Loads_Files == false)
        {
            IBM.SetActive(true);
        }
        else
        {
            HubButton.audiostop = 0;
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Goto_GameTutorial()
    {
        HubButton.audiostop = 0;
        SceneManager.LoadScene("IntroduceHowtoplay");
    }

    public void OK_Button()
    {
        IBM.SetActive(false);        
    }
}
