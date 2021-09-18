using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyPad : MonoBehaviour
{
    public Text NM;
    public GameObject Wrong_Name;

    TouchScreenKeyboard TS_한글;

    public void CodeUseText()
    {
        TS_한글 = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.ASCIICapable);
    }

    void Start()
    {
        Wrong_Name = GameObject.Find("Alarm");
        if(Wrong_Name==null)
        {

        }
        else 
            Wrong_Name.SetActive(false);
    }

    void Update()
    {
        if (TouchScreenKeyboard.visible == false && TS_한글 != null)
        {
            if (TS_한글.done)
            {
                NM.text = TS_한글.text;
                TS_한글 = null;

                if (NM.text.Length<2 || NM.text.Length>7)
                {
                    Tutorials.NameCompose = false;
                    Wrong_Name.SetActive(true);
                }
                else
                {
                    Tutorials.NameCompose = true;
                    Wrong_Name.SetActive(false);

                    SaveData.Name = NM.text;

                    SaveData.DoChangeData = true;
                }
            }
        }

        if (Application.platform==RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
