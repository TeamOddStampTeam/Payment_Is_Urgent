using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomList : MonoBehaviour
{
    public GameObject RList;
    public GameObject RMake;

    public InputField R_NAME;
    public InputField R_PW;

    public static string RoomName;//수정
    public static int Code;

    private void Start()
    {
        
    }

    private void Update()
    {
        //확인을 누를 때 방 정보를 서버로 보낸 뒤 중복된 이름이 없다면 응답코드를 받아 방 생성 후 방으로 이동
    }
}
