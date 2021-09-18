using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberKeypad : MonoBehaviour
{
    public Text CD;
    public Text ColorChange;

    TouchScreenKeyboard TS_키패드;
    private int Numbercodes = 0;
    private bool AllTextIsNumbers = true;
    public static string RoomCodes = "RESET";

    public void CodeUseNumbers()
    {
        TS_키패드 = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.PhonePad);
    }

    void Start()
    {
        
    }

    void Update()
    {
        //생성하고자 하는 코드를 입력하고자 할 때 숫자키패드 + 입력창
        if (TouchScreenKeyboard.visible == false && TS_키패드 != null)
        {
            if (TS_키패드.done)
            {
                CD.text = TS_키패드.text;

                TS_키패드 = null;

                RoomCodes = 'P'+CD.text+'G';//임시적인 데이터 저장

                char[] CodeCom = RoomCodes.ToCharArray();
                for(int x=1; ; x++)
                {
                    if (CodeCom[x] == 'G')
                    {
                        if (AllTextIsNumbers == true && CD.text.Contains("PG") == false) //조건문 수정:: 아무것도 입력이 되지 않았을 때 버그 발생
                        {
                            Numbercodes = int.Parse(CD.text);
                        }
                        break;
                    }
                    else if(CodeCom[x]>=48 && CodeCom[x] <= 57) { AllTextIsNumbers = true; }
                    else { AllTextIsNumbers = false; break; }
                }

                RoomCodes = CD.text;
                if (RoomCodes.Length == 6 && Numbercodes.ToString() == RoomCodes && AllTextIsNumbers == true)
                {
                    ColorChange.color = new Color(0/255f, 100/255f, 9/255f, 255/255f);//녹색
                }
                else
                {
                    ColorChange.color = new Color(255/255f, 0/255f, 35/255f, 255/255f);//빨간색
                }
            }
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
