using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine.UI;

public class InLobbyVar : MonoBehaviour
{
    public static Text 로비자본;
    public static Text 로비점수;

    void Awake()
    {
        SaveData.DoLoadData = true;
        //포인트 입력
        로비자본 = GameObject.Find("TestMoney").GetComponent<Text>();
        로비점수 = GameObject.Find("TestPoints").GetComponent<Text>();

        로비자본.GetComponent<Text>().text = SaveData.Money.ToString();
        로비점수.GetComponent<Text>().text = SaveData.Points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
