using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//아이템 추가시 Store_T, _I 등 모두 들어가 Store...->Shelf에서 수정
public class ItemBundss : MonoBehaviour
{
    [Header("도장명")]
    public Sprite Stamp_N_;
    public Sprite Stamp_1_;
    public Sprite Stamp_2_;
    public Sprite Stamp_3_;

    public static Sprite Stamp_N;
    public static Sprite Stamp_1;
    public static Sprite Stamp_2;
    public static Sprite Stamp_3;

    [Header("도장잉크명")]
    public Sprite Stamp_N_Ink_;
    public Sprite Stamp_1_Ink_;
    public Sprite Stamp_2_Ink_;
    public Sprite Stamp_3_Ink_;

    public static Sprite Stamp_N_Ink;
    public static Sprite Stamp_1_Ink;
    public static Sprite Stamp_2_Ink;
    public static Sprite Stamp_3_Ink;


    [Header("책상명")]
    public Sprite Table_N_;
    public Sprite Table_1_;
    public Sprite Table_2_;
    public Sprite Table_3_;

    public static Sprite Table_N;
    public static Sprite Table_1;
    public static Sprite Table_2;
    public static Sprite Table_3;

    [Header("인주명")]
    public Sprite Ink_N_;
    public Sprite Ink_1_;
    public Sprite Ink_2_;
    public Sprite Ink_3_;

    public static Sprite Ink_N;
    public static Sprite Ink_1;
    public static Sprite Ink_2;
    public static Sprite Ink_3;



    [Header("오류")]
    public Sprite ERROR_;

    public static Sprite ERROR;

    private void Start()
    {
        Stamp_N = Stamp_N_;
        Stamp_1 = Stamp_1_;
        Stamp_2 = Stamp_2_;
        Stamp_3 = Stamp_3_;

        Stamp_N_Ink = Stamp_N_Ink_;
        Stamp_1_Ink = Stamp_1_Ink_;
        Stamp_2_Ink = Stamp_2_Ink_;
        Stamp_3_Ink = Stamp_3_Ink_;

        Table_N = Table_N_;
        Table_1 = Table_1_;
        Table_2 = Table_2_;
        Table_3 = Table_3_;

        Ink_N = Ink_N_;
        Ink_1 = Ink_1_;
        Ink_2 = Ink_2_;
        Ink_3 = Ink_3_;

        ERROR = ERROR_;
    }
}
