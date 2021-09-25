using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingCustom : MonoBehaviour
{
    public Text Stuff_Name;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            Stuff_Name.GetComponent<Text>().text = HubButton.ItemGroup_S[HubButton.ListNum];
        }

        else if (SceneManager.GetActiveScene().name == "SampleScene_T")
        {
            Stuff_Name.GetComponent<Text>().text = HubButton.ItemGroup_T[HubButton.ListNum];
        }

        else if (SceneManager.GetActiveScene().name == "SampleScene_I")
        {
            Stuff_Name.GetComponent<Text>().text = HubButton.ItemGroup_I[HubButton.ListNum];
        }
         
    }

    public void choseSkin()
    {

    }

}
