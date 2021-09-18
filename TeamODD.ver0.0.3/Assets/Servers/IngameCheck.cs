using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameCheck : MonoBehaviour
{
    public int PagePoint = 0; //어느 만큼 제출을 했는지 표기

    public void SucceedToSubmit()
    {
        try
        {
            PagePoint++;
            WTClient.InformationText = PagePoint.ToString();

            WTClient.DataSend = true;
        }
        catch
        {
            UnityEngine.Debug.Log("제출 점수 전송 오류");
        }
    }
}
