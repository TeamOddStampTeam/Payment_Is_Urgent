using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public static string Name = "공분악";
    public static string Levels="사원";
    public static int Money = 999999;
    public static int Points = 0;
    public static bool[] Stamp_Get = new bool[4] { false, false, false, false };
    public static bool[] Ink_Get = new bool[4] { false, false, false, false };
    public static bool[] Table_Get = new bool[4] { false, false, false, false };

    public static string DataPath = "/Userdata.dat";

    public static bool DoChangeData = false;
    public static bool DoLoadData = false;
    public static bool RemakeDataInHub = false;

    public static bool Check_Loads_Files = false;

    [Serializable]
    public class Players
    {
        public string name_;
        public string levels_;
        public int money_;
        public int points_;
        public bool[] Stamp_Get_ = new bool[4];
        public bool[] Ink_Get_ = new bool[4];
        public bool[] Table_Get_ = new bool[4];
    }

    public static void Saves()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath+DataPath);

        Players data = new Players();

        //A--->B
        data.name_ = Name;
        data.levels_ = Levels;
        data.money_ = Money;
        data.points_ = Points;
        data.Stamp_Get_ = Stamp_Get;
        data.Ink_Get_ = Ink_Get;
        data.Table_Get_ = Table_Get;


        //B직렬화 & 파일 저장
        bf.Serialize(file, data);

        file.Close();
    }

   

    public static void Loads()
    {
        BinaryFormatter bf = new BinaryFormatter();

        try
        {
            FileStream file = File.Open(Application.persistentDataPath + DataPath, FileMode.Open);
            if (file != null && file.Length > 0)
            {
                Players data = (Players)bf.Deserialize(file);

                //B--->A
                Name = data.name_;
                Levels = data.levels_;
                Money = data.money_;
                Points = data.points_;
                Stamp_Get = data.Stamp_Get_;
                Ink_Get = data.Ink_Get_;
                Table_Get = data.Table_Get_;
            }
            Check_Loads_Files = true;
            file.Close();
        }
        catch
        {
            Check_Loads_Files = false;
        }
        
    }

    void Awake()
    {
        if (DoChangeData == true)
        {
            Saves();

            DoChangeData = false;
        }

        if (DoLoadData == true)
        {
            Loads();

            if (RemakeDataInHub == true)
            {
                InGameVar.게임로비점수.GetComponent<Text>().text = Money.ToString();
                InGameVar.게임로비자본.GetComponent<Text>().text = Money.ToString();

                InLobbyVar.로비점수.GetComponent<Text>().text = Money.ToString();
                InLobbyVar.로비자본.GetComponent<Text>().text = Money.ToString();

                StoreMovement.점수.GetComponent<Text>().text = Money.ToString();
                StoreMovement.자본.GetComponent<Text>().text = Points.ToString();
                RemakeDataInHub = false;
            }
        }
    }

    void Update()
    {
        if(DoChangeData==true)
        {
            Saves();

            DoChangeData = false;
        }

        if (DoLoadData == true)
        {
            Loads();

            if (RemakeDataInHub == true)
            {

                StoreLobbyMovement.이름확인용.GetComponent<Text>().text = Name;
                StoreLobbyMovement.레벨확인용.GetComponent<Text>().text = Levels;
                StoreLobbyMovement.자본확인용.GetComponent<Text>().text = Money.ToString();
                StoreLobbyMovement.점수확인용.GetComponent<Text>().text = Points.ToString();

                RemakeDataInHub = false;
            }

            //UnityEngine.Debug.Log(Name);
            //UnityEngine.Debug.Log(Levels);
            //UnityEngine.Debug.Log(Money.ToString());
            //UnityEngine.Debug.Log(Points.ToString());

            DoLoadData = false;
        }
    }
}
