using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoreLobbyMovement : MonoBehaviour
{
    public Text STGroup;  //화살표 가운데 텍스트
    public GameObject StempsImage;
    public GameObject ShapeImage;

    public Sprite Testsss;

    public static Text 이름확인용;
    public static Text 레벨확인용;
    public static Text 자본확인용;
    public static Text 점수확인용;

    public static int ListNum = 0;
    public static int Maxs;

    // 가운데 글씨 아이템 이름 설정
    public static string[] ItemGroup_S = new string[] { "기본 스킨", "벚꽃", "하트", "주먹", "출시예정", "출시예정", "\0" }; //추후 다른 파일에서 불러오도록 설정
    public static string[] ItemGroup_T = new string[] { "기본 스킨", "꽃", "하트", "스크래치", "출시예정", "출시예정","\0" };
    public static string[] ItemGroup_I = new string[] { "기본 스킨", "꽃무늬", "하트", "벽돌", "출시예정", "출시예정" };

    int[] StampGroup = new int[] { 0, 1, 2, 3, 4, 5 };

    //구매 관련
    public GameObject IBM;
    private string[] Stamp_Price = new string[] { "0", "50000", "50000","50000", "\0" };
    private string[] Table_Price = new string[] { "0","30000", "30000", "40000", "\0" };
    private string[] Ink_Price = new string[] { "0","40000", "40000", "40000", "\0" };
    private int Money_Save;

    public void Awake()
    {
        SaveData.DoLoadData = true;
        Money_Save = SaveData.Money;
        IBM.SetActive(false);
        Buy_Check();

        이름확인용 = GameObject.Find("TestName").GetComponent<Text>();
        레벨확인용 = GameObject.Find("TestDuty").GetComponent<Text>();
        자본확인용 = GameObject.Find("TestMoney").GetComponent<Text>();
        점수확인용 = GameObject.Find("TestPoints").GetComponent<Text>();

        자본확인용.GetComponent<Text>().text = SaveData.Money.ToString();
        점수확인용.GetComponent<Text>().text = SaveData.Points.ToString();

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
    // Start is called before the first frame update
    void Start()
    {
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

        else if (SceneManager.GetActiveScene().name == "SampleScene_T")
        {
            STGroup.GetComponent<Text>().text = ItemGroup_T[ListNum];
        }

        else if (SceneManager.GetActiveScene().name == "SampleScene_I")
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

    // Update is called once per frame
    void Update()
    {
        자본확인용.GetComponent<Text>().text = SaveData.Money.ToString();
        점수확인용.GetComponent<Text>().text = SaveData.Points.ToString();
        Buy_Check();

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
        for (int x = 0; ; x++)
        {
            if (ItemGroup_S[x].Equals("\0") || ItemGroup_T[x].Equals("\0") || ItemGroup_I[x].Equals("\0"))
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
        if (Type == "Stamp")
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

        else if (Type == "Ink")
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

    public void Wanna_Buy()
    {
        SaveData.Loads();
        UnityEngine.Debug.Log(Money_Save);
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (SaveData.Stamp_Get[ListNum] == true)
            {
                UnityEngine.Debug.Log("이미 구매함");
                return;
            }

            if(ListNum == 0)
            {
                UnityEngine.Debug.Log("기본 스킨임");
                return;
            }

            IBM.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "SampleScene_T")
        {
            if (SaveData.Table_Get[ListNum] == true)
            {
                UnityEngine.Debug.Log("이미 구매함");
                return;
            }

            if (ListNum == 0)
            {
                UnityEngine.Debug.Log("기본 스킨임");
                return;
            }
            IBM.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "SampleScene_I")
        {
            if (SaveData.Ink_Get[ListNum] == true)
            {
                UnityEngine.Debug.Log("이미 구매함");
                return;
            }

            if (ListNum == 0)
            {
                UnityEngine.Debug.Log("기본 스킨임");
                return;
            }
            IBM.SetActive(true);
        }
    }

    public void Buy_Check()
    {
        SaveData.Loads();
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (0 < ListNum && ListNum < 4)
            {
                if (SaveData.Stamp_Get[ListNum] == true)
                {
                    GameObject.Find("StampsBundle").transform.Find("NotBuy").gameObject.SetActive(false);
                    GameObject.Find("StampsBundle").transform.Find("BuyComplete").gameObject.SetActive(true);

                    GameObject goImage = GameObject.Find("ShowShape");
                    Color color = goImage.GetComponent<Image>().color;
                    color.a = 1.0f;
                    goImage.GetComponent<Image>().color = color;

                    GameObject goImage1 = GameObject.Find("ShowStamp");
                    Color color1 = goImage1.GetComponent<Image>().color;
                    color1.a = 1.0f;
                    goImage1.GetComponent<Image>().color = color1;
                }
                else
                {
                    GameObject.Find("StampsBundle").transform.Find("NotBuy").gameObject.SetActive(true);
                    GameObject.Find("StampsBundle").transform.Find("BuyComplete").gameObject.SetActive(false);

                    GameObject goImage = GameObject.Find("ShowShape");
                    Color color = goImage.GetComponent<Image>().color;
                    color.a = 0.5f;
                    goImage.GetComponent<Image>().color = color;

                    GameObject goImage1 = GameObject.Find("ShowStamp");
                    Color color1 = goImage1.GetComponent<Image>().color;
                    color1.a = 0.5f;
                    goImage1.GetComponent<Image>().color = color1;
                }
            }
            else
            {
                GameObject.Find("StampsBundle").transform.Find("NotBuy").gameObject.SetActive(false);
                GameObject.Find("StampsBundle").transform.Find("BuyComplete").gameObject.SetActive(false);

                GameObject goImage = GameObject.Find("ShowShape");
                Color color = goImage.GetComponent<Image>().color;
                color.a = 1.0f;
                goImage.GetComponent<Image>().color = color;

                GameObject goImage1 = GameObject.Find("ShowStamp");
                Color color1 = goImage1.GetComponent<Image>().color;
                color1.a = 1.0f;
                goImage1.GetComponent<Image>().color = color1;
            }
        }
        else if (SceneManager.GetActiveScene().name == "SampleScene_T")
        {
            if (0 < ListNum && ListNum < 4)
            {
                if (SaveData.Table_Get[ListNum] == true)
                {
                    GameObject.Find("StampsBundle").transform.Find("NotBuy_T").gameObject.SetActive(false);
                    GameObject.Find("StampsBundle").transform.Find("BuyComplete").gameObject.SetActive(true);

                    GameObject goImage1 = GameObject.Find("ShowStamp");
                    Color color1 = goImage1.GetComponent<Image>().color;
                    color1.a = 1.0f;
                    goImage1.GetComponent<Image>().color = color1;
                }
                else
                {
                    GameObject.Find("StampsBundle").transform.Find("NotBuy_T").gameObject.SetActive(true);
                    GameObject.Find("StampsBundle").transform.Find("BuyComplete").gameObject.SetActive(false);

                    GameObject goImage1 = GameObject.Find("ShowStamp");
                    Color color1 = goImage1.GetComponent<Image>().color;
                    color1.a = 0.5f;
                    goImage1.GetComponent<Image>().color = color1;
                }
            }
            else
            {
                GameObject.Find("StampsBundle").transform.Find("NotBuy_T").gameObject.SetActive(false);
                GameObject.Find("StampsBundle").transform.Find("BuyComplete").gameObject.SetActive(false);

                GameObject goImage1 = GameObject.Find("ShowStamp");
                Color color1 = goImage1.GetComponent<Image>().color;
                color1.a = 1.0f;
                goImage1.GetComponent<Image>().color = color1;
            }
        }
        else if (SceneManager.GetActiveScene().name == "SampleScene_I")
        {
            if (0 < ListNum && ListNum < 4)
            {
                if (SaveData.Ink_Get[ListNum] == true)
                { //구매 완료
                    GameObject.Find("StampsBundle").transform.Find("NotBuy_I").gameObject.SetActive(false);
                    GameObject.Find("StampsBundle").transform.Find("BuyComplete").gameObject.SetActive(true);

                    GameObject goImage = GameObject.Find("ShowShape");
                    Color color = goImage.GetComponent<Image>().color;
                    color.a = 1.0f;
                    goImage.GetComponent<Image>().color = color;

                    GameObject goImage1 = GameObject.Find("ShowStamp");
                    Color color1 = goImage1.GetComponent<Image>().color;
                    color1.a = 1.0f;
                    goImage1.GetComponent<Image>().color = color1;

                }
                else
                { //구매하기 전
                    GameObject.Find("StampsBundle").transform.Find("NotBuy_I").gameObject.SetActive(true);
                    GameObject.Find("StampsBundle").transform.Find("BuyComplete").gameObject.SetActive(false);


                    GameObject goImage = GameObject.Find("ShowShape");
                    Color color = goImage.GetComponent<Image>().color;
                    color.a = 0.5f;
                    goImage.GetComponent<Image>().color = color;

                    GameObject goImage1 = GameObject.Find("ShowStamp");
                    Color color1 = goImage1.GetComponent<Image>().color;
                    color1.a = 0.5f;
                    goImage1.GetComponent<Image>().color = color1;

                }
            }
            else
            { //구매하기 전
                GameObject.Find("StampsBundle").transform.Find("NotBuy_I").gameObject.SetActive(false);
                GameObject.Find("StampsBundle").transform.Find("BuyComplete").gameObject.SetActive(false);

                GameObject goImage = GameObject.Find("ShowShape");
                Color color = goImage.GetComponent<Image>().color;
                color.a = 1.0f;
                goImage.GetComponent<Image>().color = color;

                GameObject goImage1 = GameObject.Find("ShowStamp");
                Color color1 = goImage1.GetComponent<Image>().color;
                color1.a = 1.0f;
                goImage1.GetComponent<Image>().color = color1;
            }
        }
    }

    public void Buy_It()
    {
        SaveData.Loads();
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            //재화가 있는지 확인
            if (Money_Save >= int.Parse(Stamp_Price[ListNum]))//있다면 결재
            {
                Money_Save = Money_Save - int.Parse(Stamp_Price[ListNum]);
                자본확인용.GetComponent<Text>().text = Money_Save.ToString();
                SaveData.Stamp_Get[ListNum] = true;
                SaveData.Money = Money_Save;
                SaveData.Saves();
            }
            else//없으면 종료
            {
                자본확인용.GetComponent<Text>().text = Money_Save.ToString();
                UnityEngine.Debug.Log("금액 부족");
                UnityEngine.Debug.Log(SaveData.Money);
            }
        }
        else if (SceneManager.GetActiveScene().name == "SampleScene_T")
        {
            //재화가 있는지 확인
            if (Money_Save >= int.Parse(Table_Price[ListNum]))//있다면 결재
            {
                Money_Save = Money_Save - int.Parse(Table_Price[ListNum]);
                자본확인용.GetComponent<Text>().text = Money_Save.ToString();
                SaveData.Table_Get[ListNum] = true;
                SaveData.Money = Money_Save;
                SaveData.Saves();
            }
            else//없으면 종료
            {
                자본확인용.GetComponent<Text>().text = Money_Save.ToString();
                UnityEngine.Debug.Log("금액 부족");
                UnityEngine.Debug.Log(SaveData.Money);
            }
        }
        else if (SceneManager.GetActiveScene().name == "SampleScene_I")
        {
            //재화가 있는지 확인
            if (Money_Save >= int.Parse(Ink_Price[ListNum]))//있다면 결재
            {
                Money_Save = Money_Save - int.Parse(Ink_Price[ListNum]);
                자본확인용.GetComponent<Text>().text = Money_Save.ToString();
                SaveData.Ink_Get[ListNum] = true;
                SaveData.Money = Money_Save;
                SaveData.Saves();
            }
            else//없으면 종료
            {
                자본확인용.GetComponent<Text>().text = Money_Save.ToString();
                UnityEngine.Debug.Log("금액 부족");
                UnityEngine.Debug.Log(SaveData.Money);
            }
        }
        SaveData.Saves();
        IBM.SetActive(false);
        SaveData.Loads();
    }

    public void IM_Mistake()
    {
        IBM.SetActive(false);
    }
}
