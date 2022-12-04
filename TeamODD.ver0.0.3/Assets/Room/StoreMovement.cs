using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Store 안에서 작업을 하면 SaveData.Money가 0으로 되는 버그가 생김
//??
public class StoreMovement : MonoBehaviour
{
    public static string[] Stamp_Item = new string[] { "꽃무늬", "하트", "주먹질","\0" };
    private string[] Stamp_Price = new string[] { "50000", "50000", "50000", "\0" };
    public static string[] Table_Item = new string[] { "꽃", "하트","스크래치", "\0" };
    private string[] Table_Price = new string[] { "30000", "30000", "40000", "\0" };
    public static string[] Ink_Item = new string[] { "꽃무늬", "하트","벽돌", "\0" };
    private string[] Ink_Price = new string[] { "40000", "40000", "40000", "\0" };

    static int ST_Line = 0;
    static int TA_Line = 0;
    static int IN_Line = 0;

    public GameObject IBM;
    public Image Prod_Img;
    public Text Names;

    public static Text 자본;
    public static Text 점수;

    private int Money_Save;
    private int Points_Save;

    public void Awake()
    {
        SaveData.DoLoadData = true;
        SaveData.Loads();
        //포인트 입력
        자본 = GameObject.Find("Money").GetComponent<Text>();
        점수 = GameObject.Find("Points").GetComponent<Text>();

        자본.GetComponent<Text>().text = SaveData.Money.ToString();
        점수.GetComponent<Text>().text = SaveData.Points.ToString();

        Money_Save = SaveData.Money;
        Points_Save = SaveData.Points;
        IBM.SetActive(false);
        
        if (SceneManager.GetActiveScene().name == "Store")
        {
            Names.GetComponent<Text>().text = Stamp_Item[ST_Line];
            Prod_Img.GetComponent<Image>().sprite = Selecting_Stuff("Stamp", ST_Line); //첫 시작시 활성화 안됨
        }
        else if (SceneManager.GetActiveScene().name == "Store_T")
        {
            Names.GetComponent<Text>().text = Table_Item[TA_Line];
            Prod_Img.GetComponent<Image>().sprite = Selecting_Stuff("Table", TA_Line);
        }
        else if (SceneManager.GetActiveScene().name == "Store_I")
        {
            Names.GetComponent<Text>().text = Ink_Item[IN_Line];
            Prod_Img.GetComponent<Image>().sprite = Selecting_Stuff("Ink", IN_Line);
        }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Store")
        {
            Names.GetComponent<Text>().text = Stamp_Item[ST_Line];
            Prod_Img.GetComponent<Image>().sprite = Selecting_Stuff("Stamp", ST_Line);
        }
        else if (SceneManager.GetActiveScene().name == "Store_T")
        {
            Names.GetComponent<Text>().text = Table_Item[TA_Line];
            Prod_Img.GetComponent<Image>().sprite = Selecting_Stuff("Table", TA_Line);
        }
        else if (SceneManager.GetActiveScene().name == "Store_I")
        {
            Names.GetComponent<Text>().text = Ink_Item[IN_Line];
            Prod_Img.GetComponent<Image>().sprite = Selecting_Stuff("Ink", IN_Line);
        }
    }
    public void BackToTheHub()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Store_Button_Stamp()
    {
        SceneManager.LoadScene("Store");
    }
    public void Store_Button_Ink()
    {
        SceneManager.LoadScene("Store_I");
    }
    public void Store_Button_Table()
    {
        SceneManager.LoadScene("Store_T");
    }

    public void Goto_Forward()
    {
        if (SceneManager.GetActiveScene().name== "Store")
        {
            if (Stamp_Item[ST_Line + 1] == "\0")
                return;
            else
                ST_Line++;

            Names.GetComponent<Text>().text = Stamp_Item[ST_Line];
            Selecting_Stuff("Stamp", ST_Line);
        }
        else if (SceneManager.GetActiveScene().name == "Store_T")
        {
            if (Stamp_Item[TA_Line + 1] == "\0")
                return;
            else
                TA_Line++;

            Names.GetComponent<Text>().text = Table_Item[TA_Line];
            Prod_Img.GetComponent<Image>().sprite = Selecting_Stuff("Table", TA_Line);
        }
        else if (SceneManager.GetActiveScene().name == "Store_I")
        {
            if (Stamp_Item[IN_Line + 1] == "\0")
                return;
            else
                IN_Line++;

            Names.GetComponent<Text>().text = Ink_Item[IN_Line];
            Prod_Img.GetComponent<Image>().sprite = Selecting_Stuff("Ink", IN_Line);
        }
    }

    public void Goto_Backward()
    {
        if (SceneManager.GetActiveScene().name== "Store")
        {
            if (ST_Line == 0)
                return;
            else
                ST_Line--;

            Names.GetComponent<Text>().text = Stamp_Item[ST_Line];
            Prod_Img.GetComponent<Image>().sprite = Selecting_Stuff("Stamp", ST_Line);
        }
        else if (SceneManager.GetActiveScene().name == "Store_T")
        {
            if (TA_Line == 0)
                return;
            else
                TA_Line--;

            Names.GetComponent<Text>().text = Table_Item[TA_Line];
            Prod_Img.GetComponent<Image>().sprite = Selecting_Stuff("Table", TA_Line);
        }
        else if (SceneManager.GetActiveScene().name == "Store_I")
        {
            if (IN_Line == 0)
                return;
            else
                IN_Line--;

            Names.GetComponent<Text>().text = Ink_Item[IN_Line];
            Prod_Img.GetComponent<Image>().sprite = Selecting_Stuff("Ink", IN_Line);
        }
    }

    public void Wanna_Buy()
    {
        SaveData.Loads();
        UnityEngine.Debug.Log(Money_Save);
        if (SceneManager.GetActiveScene().name == "Store")
        {
            if(SaveData.Stamp_Get[ST_Line]==true)
            {
                UnityEngine.Debug.Log("이미 구매함");
                return;
            }
            IBM.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Store_T")
        {
            if (SaveData.Table_Get[TA_Line] == true)
            {
                UnityEngine.Debug.Log("이미 구매함");
                return;
            }
            IBM.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Store_I")
        {
            if (SaveData.Ink_Get[IN_Line] == true)
            {
                UnityEngine.Debug.Log("이미 구매함");
                return;
            }
            IBM.SetActive(true);
        }
    }

    public void Buy_It()
    {
        SaveData.Loads();
        if (SceneManager.GetActiveScene().name == "Store")
        {
            //재화가 있는지 확인
            if (Money_Save >= int.Parse(Stamp_Price[ST_Line]))//있다면 결재
            {
                Money_Save = Money_Save - int.Parse(Stamp_Price[ST_Line]);
                자본.GetComponent<Text>().text = Money_Save.ToString();
                SaveData.Stamp_Get[ST_Line] = true;
                SaveData.Money = Money_Save;
                SaveData.Saves();
            }
            else//없으면 종료
            {
                자본.GetComponent<Text>().text = Money_Save.ToString();
                UnityEngine.Debug.Log("금액 부족");
                UnityEngine.Debug.Log(SaveData.Money);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Store_T")
        {
            //재화가 있는지 확인
            if (Money_Save >= int.Parse(Table_Price[TA_Line]))//있다면 결재
            {
                Money_Save = Money_Save - int.Parse(Table_Price[TA_Line]);
                자본.GetComponent<Text>().text = Money_Save.ToString();
                SaveData.Table_Get[TA_Line] = true;
                SaveData.Money = Money_Save;
                SaveData.Saves();
            }
            else//없으면 종료
            {
                자본.GetComponent<Text>().text = Money_Save.ToString();
                UnityEngine.Debug.Log("금액 부족");
                UnityEngine.Debug.Log(SaveData.Money);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Store_I")
        {
            //재화가 있는지 확인
            if (Money_Save >= int.Parse(Ink_Price[IN_Line]))//있다면 결재
            {
                Money_Save = Money_Save - int.Parse(Ink_Price[IN_Line]);
                자본.GetComponent<Text>().text = Money_Save.ToString();
                SaveData.Ink_Get[IN_Line] = true;
                SaveData.Money = Money_Save;
                SaveData.Saves();
            }
            else//없으면 종료
            {
                자본.GetComponent<Text>().text = Money_Save.ToString();
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

    public void Go_Back_To_Lobby()
    {
        SceneManager.LoadScene("SampleScene");
    }

    /*private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }*/

    public Sprite Selecting_Stuff(string Type, int Number)//상품 추가시 수정할 것
    {
        if(Type=="Stamp")
        {
            if (Number == 0) {
                UnityEngine.Debug.Log("도장1");
                return ItemBundss.Stamp_1; }
            else if (Number == 1) { return ItemBundss.Stamp_2; }
            else if (Number == 2) { return ItemBundss.Stamp_3; }
        }
        else if(Type=="Table")
        {
            if (Number == 0) { return ItemBundss.Table_1; }
            else if (Number == 1) { return ItemBundss.Table_2; }
            else if (Number == 2) { return ItemBundss.Table_3; }
        }
        else if(Type=="Ink")
        {
            if (Number == 0) { return ItemBundss.Ink_1; }
            else if (Number == 1) { return ItemBundss.Ink_2; }
            else if (Number == 2) { return ItemBundss.Ink_3; }
        }

        return ItemBundss.ERROR;
    }
}
