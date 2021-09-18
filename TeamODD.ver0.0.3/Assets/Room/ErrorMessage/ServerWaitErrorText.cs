using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerWaitErrorText : MonoBehaviour
{
    public static int SWET_Error = 0;
    string[] Msgs = new string[] { "대기 텍스트","예기치 못한 문제로 인해 통신이 중단됩니다.", "호스트 서버에 문제가 발생했습니다.", "클라이언트 통신에 문제가 발생했습니다.", "인터넷 연결이 되어있지 않습니다." };

    [Header("서버 에러 테스트")]
    public Text 에러메시지;

    private void Start()
    {
        if(SWET_Error>4)
        {
            에러메시지.GetComponent<Text>().text = "???";
            return;
        }
        에러메시지.GetComponent<Text>().text =Msgs[SWET_Error];
    }
}
