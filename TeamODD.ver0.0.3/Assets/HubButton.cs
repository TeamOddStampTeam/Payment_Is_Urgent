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

    public static int ListNum=0, Maxs;
    public static string[] ItemGroup=new string[] { "기본 스킨","커스텀 1", "커스텀 2", "커스텀 3", "커스텀 4", "커스텀 5", "\0"}; //추후 다른 파일에서 불러오도록 설정
    int[] StampGroup = new int[] { 0, 1, 2, 3, 4, 5};
    int[] ShapeGroup = new int[] { 0, 1, 2, 3, 4, 5 };
   

    void Start()
    {
        Canvas = GameObject.Find("GroupGameButton");
        MatchLoading = GameObject.Find("Matching");

        choseStampSkin();
        choseStampInkSkin();

        SaveData.DoLoadData = true;

        STGroup.GetComponent<Text>().text = ItemGroup[ListNum];

        이름확인용 = GameObject.Find("TestName").GetComponent<Text>();
        레벨확인용 = GameObject.Find("TestDuty").GetComponent<Text>();
        자본확인용 = GameObject.Find("TestMoney").GetComponent<Text>();
        점수확인용 = GameObject.Find("TestPoints").GetComponent<Text>();

        자본확인용.GetComponent<Text>().text = SaveData.Money.ToString();
        점수확인용.GetComponent<Text>().text = SaveData.Points.ToString();

        UnityEngine.Debug.Log(SaveData.Money);
    }
    public void FAR()
    {
        ListNum++;
        if (ListNum == Maxs+1)
            ListNum = 0;
        STGroup.GetComponent<Text>().text = ItemGroup[ListNum];
        choseStampSkin();
        choseStampInkSkin();
        //if (StampGroup[ListNum] == 3) { StempsImage.GetComponent<Image>().sprite = Testsss; } //나중에 임시저장 형식으로 만들어서 불러오기 가능하게 & 해당 번호에 따른 스프라이트 지정 함수를 만들기

        //UnityEngine.Debug.Log("Front Arrow");
    }

    public void choseStampInkSkin()
    {
        if (StampGroup[ListNum] == 0)
        {
           // Debug.Log("기본스킨 + Stamp_N_Ink");
            ShapeImage.GetComponent<Image>().sprite = ItemBundss.Stamp_N_Ink;
        }
        else if (StampGroup[ListNum] == 1)
        {
            if (SaveData.Stamp_Get[0] == true)
            {
                //Debug.Log("커스텀1 + Stamp_1");
                ShapeImage.GetComponent<Image>().sprite = ItemBundss.Stamp_1;
            }
            else ShapeImage.GetComponent<Image>().sprite = Testsss;
        }
        else if (StampGroup[ListNum] == 2)
        {
            if (SaveData.Stamp_Get[1] == true)
            {
                //Debug.Log("커스텀2 + Stamp_2");
                ShapeImage.GetComponent<Image>().sprite = ItemBundss.Stamp_2;
            }
            else ShapeImage.GetComponent<Image>().sprite = Testsss;
        }
        else if (StampGroup[ListNum] == 3)
        {
            if (SaveData.Stamp_Get[2] == true)
            {
                //Debug.Log("커스텀3 + Stamp_3");
                ShapeImage.GetComponent<Image>().sprite = ItemBundss.Stamp_3;
            }
            else ShapeImage.GetComponent<Image>().sprite = Testsss;
        }
        else ShapeImage.GetComponent<Image>().sprite = Testsss;
    }

    public void choseStampSkin()
    {
        if (StampGroup[ListNum] == 0)
        {
            //Debug.Log("기본스킨 + Stamp_N");
            StempsImage.GetComponent<Image>().sprite = ItemBundss.Stamp_N;
        }
        else if (StampGroup[ListNum] == 1)
        {
            if (SaveData.Stamp_Get[0] == true)
            {
                //Debug.Log("커스텀1 + Stamp_1");
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Stamp_1;
            }
            else StempsImage.GetComponent<Image>().sprite = Testsss;
        }
        else if (StampGroup[ListNum] == 2) {
            if (SaveData.Stamp_Get[1] == true)
            {
                //Debug.Log("커스텀2 + Stamp_2");
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Stamp_2;
            }
            else StempsImage.GetComponent<Image>().sprite = Testsss;
        }
        else if (StampGroup[ListNum] == 3)
        {
            if (SaveData.Stamp_Get[2] == true)
            {
                //Debug.Log("커스텀3 + Stamp_3");
                StempsImage.GetComponent<Image>().sprite = ItemBundss.Stamp_3;
            }
            else StempsImage.GetComponent<Image>().sprite = Testsss;
        }
        else StempsImage.GetComponent<Image>().sprite = Testsss;
    }

    public void BAR()
    {
        ListNum--;
        if (ListNum == -1)
            ListNum = Maxs;
        STGroup.GetComponent<Text>().text = ItemGroup[ListNum];
        choseStampSkin();
        choseStampInkSkin();
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
        SceneManager.LoadScene("Store");
    }
    public void ShopTableSkins()
    {
        //UnityEngine.Debug.Log("Open Table");
        SceneManager.LoadScene("Store_T");
    }
    public void ShopInkSkins()
    {
        //UnityEngine.Debug.Log("Open Ink");
        SceneManager.LoadScene("Store_I");
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
        for (int x=0; ; x++)
        {
            if (ItemGroup[x].Equals("\0"))
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
}
