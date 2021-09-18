using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCode : MonoBehaviour
{
    public void Cancel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Accept()
    {
        if(NumberKeypad.RoomCodes.Length==6)//6자리 숫자일 때
        {
            SceneManager.LoadScene("ServerWait");

            WTClient.PlayEnterServer_KP = true;
        }
        else
        {
            //무응답
        }
    }
}
