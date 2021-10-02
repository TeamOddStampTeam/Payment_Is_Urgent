using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HubButton : MonoBehaviour
{
    public GameObject Canvas;
    public Text STGroup;  //화살표 가운데 텍스트
    public GameObject StempsImage;
    public GameObject ShapeImage;
    public GameObject MatchLoading;

    public Sprite Testsss;

    public static Text 이름확인용;
    public static Text 레벨확인용;
    public static Text 자본확인용;
    public static Text 점수확인용;

    public static int ListNum = 0, Maxs;
    
    // 가운데 글씨 아이템 이름 설정
    public static string[] ItemGroup_S = new string[] { "기본 스킨", "벚꽃", "하트", "주먹", "출시 예정", "출시 예정", "\0" }; //추후 다른 파일에서 불러오도록 설정
    public static string[] ItemGroup_T = new string[] { "기본 스킨", "꽃", "하트", "스크래치", "출시예정", "출시예정" };
    public static string[] ItemGroup_I = new string[] { "기본 스킨", "꽃무늬", "하트", "벽돌", "출시예정", "출시예정" };

    int[] StampGroup = new int[] { 0, 1, 2, 3, 4, 5 };


    private void Awake()
    {
        SaveData.DoLoadData = true;

        이름확인용 = GameObject.Find("TestName").GetComponent<Text>();
        레벨확인용 = GameObject.Find("TestDuty").GetComponent<Text>();
        자본확인용 = GameObject.Find("TestMoney").GetComponent<Text>();
        점수확인용 = GameObject.Find("TestPoints").GetComponent<Text>();

        자본확인용.GetComponent<Text>().text = SaveData.Money.ToString();
        점수확인용.GetComponent<Text>().text = SaveData.Points.ToString();

        //여기 왜 오류나징
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            STGroup.GetComponent<Text>().text = ItemGroup_S[ListNum];
            StempsImage.GetComponent<Image>().sprite = ItemBundss.Stamp_N;
            ShapeImage.GetComponent<Image>().sprite = ItemBundss.Stamp_N_Ink;
        }

        else if (SceneManager.GetActiveScene().name == "SampleScene_T")
        {
            STGroup.GetComponent<Text>().text = ItemGroup_T[ListNum];
            StempsImage.GetComponent<Image>().sprite = ItemBundss.Table_N;
            //ShapeImage.GetComponent<Image>().sprite = Testsss;
        }

        else if (SceneManager.GetActiveScene().name == "SampleScene_I")
        {
            STGroup.GetComponent<Text>().text = ItemGroup_I[ListNum];
            StempsImage.GetComponent<Image>().sprite = ItemBundss.Ink_N;
            ShapeImage.GetComponent<Image>().sprite = ItemBundss.Close_Ink_N;
        }

        UnityEngine.Debug.Log(SaveData.Money);
    }

    void Start()
    {
        Canvas = GameObject.Find("GroupGameButton");
        MatchLoading = GameObject.Find("Matching");
        ListNum = 0;

        choseStampSkin();

        

    }
    public void FAR()
    {
        ListNum++;
        if (ListNum == Maxs + 1)
            ListNum = 0;

        // 버튼 가운데 아이템 이름 설정
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            STGroup.GetComponent<Text>().text = ItemGroup_S[ListNum];
        }

        else if(SceneManager.GetActiveScene().name == "SampleScene_T")
        {
            STGroup.GetComponent<Text>().text = ItemGroup_T[ListNum];
        }

        else if(SceneManager.GetActiveScene().name == "SampleScene_I")
        {
            STGroup.GetComponent<Text>().text = ItemGroup_I[ListNum];
        }
        
        choseStampSkin();
        //if (StampGroup[ListNum] == 3) { StempsImage.GetComponent<Image>().sprite = Testsss; } //나중에 임시저장 형식으로 만들어서 불러오기 가능하게 & 해당 번호에 따른 스프라이트 지정 함수를 만들기

        //UnityEngine.Debug.Log("Front Arrow");
    }

    public void choseStampSkin()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (StampGroup[ListNum] == 0)
            {
                // Debug.Log("기본스킨 + Stamp_N_Ink");
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Stamp_N;
                ShapeImage.GetComponent<Image>().sprite = ItemBundss.Stamp_N_Ink;
            }
            else if (StampGroup[ListNum] == 1)
            {
                //Debug.Log("커스텀1 + Stamp_1");
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Stamp_1;
                ShapeImage.GetComponent<Image>().sprite = ItemBundss.Stamp_1_Ink;

            }
            else if (StampGroup[ListNum] == 2)
            {
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Stamp_2;
                ShapeImage.GetComponent<Image>().sprite = ItemBundss.Stamp_2_Ink;

            }
            else if (StampGroup[ListNum] == 3)
            {
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Stamp_3;
                ShapeImage.GetComponent<Image>().sprite = ItemBundss.Stamp_3_Ink;

            }
            else
            {
                StempsImage.GetComponent<Image>().sprite = Testsss;
                ShapeImage.GetComponent<Image>().sprite = Testsss;
            }
        }

        else if (SceneManager.GetActiveScene().name == "SampleScene_T")
        {
            if (StampGroup[ListNum] == 0)
            {
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Table_N;
                //ShapeImage.GetComponent<Image>().sprite = Testsss;
            }
            else if (StampGroup[ListNum] == 1)
            {
                //Debug.Log("커스텀1 + Stamp_1");
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Table_1;
                //ShapeImage.GetComponent<Image>().sprite = Testsss;

            }
            else if (StampGroup[ListNum] == 2)
            {
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Table_2;
                //ShapeImage.GetComponent<Image>().sprite = Testsss;

            }
            else if (StampGroup[ListNum] == 3)
            {
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Table_3;
                //ShapeImage.GetComponent<Image>().sprite = Testsss;

            }
            else
            {
                StempsImage.GetComponent<Image>().sprite = Testsss;
                //ShapeImage.GetComponent<Image>().sprite = Testsss;
            }
        }

        else if (SceneManager.GetActiveScene().name == "SampleScene_I")
        {
            if (StampGroup[ListNum] == 0)
            {
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Ink_N;
                ShapeImage.GetComponent<Image>().sprite = ItemBundss.Close_Ink_N;
            }
            else if (StampGroup[ListNum] == 1)
            {
                //Debug.Log("커스텀1 + Stamp_1");
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Ink_1;
                ShapeImage.GetComponent<Image>().sprite = ItemBundss.Close_Ink_1;
            }
            else if (StampGroup[ListNum] == 2)
            {
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Ink_2;
                ShapeImage.GetComponent<Image>().sprite = ItemBundss.Close_Ink_2;

            }
            else if (StampGroup[ListNum] == 3)
            {
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Ink_3;
                ShapeImage.GetComponent<Image>().sprite = ItemBundss.Close_Ink_3;

            }
            else
            {
                StempsImage.GetComponent<Image>().sprite = Testsss;
                ShapeImage.GetComponent<Image>().sprite = Testsss;
            }
        }
    }


 

    public void BAR()
    {
        ListNum--;
        if (ListNum == -1)
            ListNum = Maxs;
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            STGroup.GetComponent<Text>().text = ItemGroup_S[ListNum];
        }

        else if (SceneManager.GetActiveScene().name == "SampleScene_T")
        {
            STGroup.GetComponent<Text>().text = ItemGroup_T[ListNum];
        }

        else if (SceneManager.GetActiveScene().name == "SampleScene_I")
        {
            STGroup.GetComponent<Text>().text = ItemGroup_I[ListNum];
        }
        choseStampSkin();
        //UnityEngine.Debug.Log("Back Arrow");
    }

    public void PlayAutoMatch()
    {
        SceneManager.LoadScene("ServerWait");

        WTClient.PlayEnterServer = true;
    }
    public void JoinRoomToPlay()
    {
        //UnityEngine.Debug.Log("Join Room");
        SceneManager.LoadScene("GameLobby");
    }

    public void ShopStampSkins()
    {
        //UnityEngine.Debug.Log("Open Stamp");
        SceneManager.LoadScene("SampleScene");
    }
    public void ShopTableSkins()
    {
        //UnityEngine.Debug.Log("Open Table");
        SceneManager.LoadScene("SampleScene_T");
    }
    public void ShopInkSkins()
    {
        //UnityEngine.Debug.Log("Open Ink");
        SceneManager.LoadScene("SampleScene_I");
    }
    public void Options()
    {
        //UnityEngine.Debug.Log("Open Option");
        SaveData.RemakeDataInHub = true;
        SaveData.DoLoadData = true;
    }
    public void Custom()
    {
        SceneManager.LoadScene("MyStorage");
    }

    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            STGroup.GetComponent<Text>().text = ItemGroup_S[ListNum];
            StempsImage.GetComponent<Image>().sprite = Selecting_Stuff_Lobby("Stamp", StampGroup[ListNum]);
            ShapeImage.GetComponent<Image>().sprite = Selecting_Stuff_Lobby("Stamp_Ink", StampGroup[ListNum]);
        }

        else if (SceneManager.GetActiveScene().name == "SampleScene_T")
        {
            STGroup.GetComponent<Text>().text = ItemGroup_T[ListNum];
            StempsImage.GetComponent<Image>().sprite = Selecting_Stuff_Lobby("Table", StampGroup[ListNum]);
            //ShapeImage.GetComponent<Image>().sprite = Testsss;
        }

        else if (SceneManager.GetActiveScene().name == "SampleScene_I")
        {
            STGroup.GetComponent<Text>().text = ItemGroup_I[ListNum];
            StempsImage.GetComponent<Image>().sprite = Selecting_Stuff_Lobby("Ink", StampGroup[ListNum]);
            ShapeImage.GetComponent<Image>().sprite = Selecting_Stuff_Lobby("Close_Ink", StampGroup[ListNum]);
        }
        for (int x=0; ; x++)
        {
            if (ItemGroup_S[x].Equals("\0")|| ItemGroup_T[x].Equals("\0")|| ItemGroup_I[x].Equals("\0"))
            {
                Maxs = x - 1;
                break;
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public Sprite Selecting_Stuff_Lobby(string Type, int Number)
    {
        if(Type == "Stamp")
        {
            if (Number == 0) return ItemBundss.Stamp_N;
            else if (Number == 1) return ItemBundss.Stamp_1;
            else if (Number == 2) return ItemBundss.Stamp_2;
            else if (Number == 3) return ItemBundss.Stamp_3;
            else return Testsss;
        }

        else if (Type == "Stamp_Ink")
        {
            if (Number == 0) return ItemBundss.Stamp_N_Ink;
            else if (Number == 1) return ItemBundss.Stamp_1_Ink;
            else if (Number == 2) return ItemBundss.Stamp_2_Ink;
            else if (Number == 3) return ItemBundss.Stamp_3_Ink;
            else return Testsss;
        }

        else if (Type == "Table")
        {
            if (Number == 0) { return ItemBundss.Table_N; }
            else if (Number == 1) { return ItemBundss.Table_1; }
            else if (Number == 2) { return ItemBundss.Table_2; }
            else if (Number == 3) { return ItemBundss.Table_3; }
            else return Testsss;
        }

        else if(Type == "Ink")
        {
            if (Number == 0) { return ItemBundss.Ink_N; }
            else if (Number == 1) { return ItemBundss.Ink_1; }
            else if (Number == 2) { return ItemBundss.Ink_2; }
            else if (Number == 3) { return ItemBundss.Ink_3; }
            else return Testsss;
        }

        else if (Type == "Close_Ink")
        {
            if (Number == 0) { return ItemBundss.Close_Ink_N; }
            else if (Number == 1) { return ItemBundss.Close_Ink_1; }
            else if (Number == 2) { return ItemBundss.Close_Ink_2; }
            else if (Number == 3) { return ItemBundss.Close_Ink_3; }
            else return Testsss;
        }

        return ItemBundss.ERROR;
    }
}
