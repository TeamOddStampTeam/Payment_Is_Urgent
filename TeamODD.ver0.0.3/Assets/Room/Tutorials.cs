using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorials : MonoBehaviour
{
    int Maps ;
    public static bool NameCompose=true;
    static bool Ends = false;

    public GameObject T_1;
    public GameObject T_2;
    public GameObject T_3;
    public GameObject T_4;
    public GameObject T_5;
    public GameObject T_6;
    public GameObject T_7;

    public GameObject OuterButton;
    public GameObject Grad_Display;

    public InputField Name_;

    void Start()
    {
        T_1 = GameObject.Find("Title_1");
        T_2 = GameObject.Find("Title_2");
        T_3 = GameObject.Find("Title_3");
        T_4 = GameObject.Find("Title_4");
        T_5 = GameObject.Find("Title_5");
        T_6 = GameObject.Find("Title_6");
        T_7 = GameObject.Find("Title_7");

        Maps = 0;

        OuterButton.SetActive(false);
        T_1.SetActive(false);
        T_2.SetActive(false);
        T_3.SetActive(false);
        T_4.SetActive(false);
        T_5.SetActive(false);
        T_6.SetActive(false);
        T_7.SetActive(false);
        SetObject(Maps);
    }

    public void NextClick()
    {
        if(NameCompose==true)
        {
            Maps++;
            SetObject(Maps);
        }
        return;
    }

    private void SetObject(int PB)
    {
        bool[] ObInvisible = new bool[7+1] { false, false, false, false, false, false, false, false };
        ObInvisible[PB] = true;
        T_1.SetActive(ObInvisible[0]);
        T_2.SetActive(ObInvisible[1]);
        T_3.SetActive(ObInvisible[2]);
        T_4.SetActive(ObInvisible[3]);
        T_5.SetActive(ObInvisible[4]);
        T_6.SetActive(ObInvisible[5]);
        T_7.SetActive(ObInvisible[6]);
        Ends = ObInvisible[7];

        if(ObInvisible[1]==true)
        {
            SaveData.DoChangeData = true;
        }
        else if(ObInvisible[0]==false && ObInvisible[1]==false)
        {
            Grad_Display.SetActive(false);
            OuterButton.SetActive(true);
        }

        if(Ends==true)
        {
            OuterButton.SetActive(false);
            SceneManager.LoadScene("SampleScene");
        }
    }

    void Update()
    {

    }
}
