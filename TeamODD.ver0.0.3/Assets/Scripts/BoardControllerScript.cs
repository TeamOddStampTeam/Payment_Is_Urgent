using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardControllerScript : MonoBehaviour
{
    public GameObject stampPrefab;
    public GameObject stampInjuAnimation;
    public GameObject injuAmount;

    public Text injuText;

    GameObject stampInjuTap;
    GameObject stampInju;

    Vector2 mouseUpPosition;
    Vector2 mouseDownPosition;

    public bool stampTouch = false;
    public bool otherTouch = false;

    private bool waxOn = false;
    private bool stampInjuOpen = false;
    private bool stampInjuTouch = false;
    private int inkValue = 10;

    public int stamp;

    // Start is called before the first frame update
    void Start()
    {
        injuText.text = "x10";
        stampInjuTap = GameObject.Find("StampInjuTapObj");
        stampInjuTap.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {
            //stamp board click 도장 생성
            if (hit.transform.gameObject.tag == "StampBoard")
            {
                if (waxOn == false)
                {
                    if (inkValue > 0)
                    {
                        if (stampTouch == false)
                        {
                            inkValue--;
                            injuText.text = "x" + inkValue;
                            Instantiate(stampPrefab, new Vector2(touchPos.x, touchPos.y), Quaternion.identity);
                            SoundManager.soundManager.StampTapPlaySound();

                            if (hit.transform.gameObject.name == "StampBoardTap")
                            {
                                if (otherTouch == false)
                                {
                                    GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().Score();
                                }
                            }
                            else
                            {
                                otherTouch = true;

                            }
                        }
                    }

                    else
                    {
                        SoundManager.soundManager.StampEmptyPlaySound();
                    }
                }

            }

            //수정 *********

            //stamp inju click
            if (hit.transform.gameObject.name == "StampInjuObj")
            {
                //inju fill
                if (stampInjuOpen == true)
                {
                    inkValue = 10;
                    injuText.text = "x" + inkValue;
                    stampInju = hit.transform.gameObject;
                    stampInjuTap.GetComponent<SpriteRenderer>().enabled = true;
                    stampInjuOpen = false;
                    Invoke("InjuClose", 0.3f);
                    
                }
                else
                {
                   
                    mouseDownPosition = touchPos;
                    stampInjuTouch = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            //stamp inju click
            if (stampInjuTouch == true)
            {
                mouseUpPosition = touchPos;

                //inju open
                if (mouseUpPosition.y > mouseDownPosition.y + 0.3f)
                {
                    if (hit.transform.gameObject.name == "StampInjuObj")
                    {
                        SoundManager.soundManager.INZ_1PlaySound();
                        hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/StampInjuFullImg");
                        stampInjuOpen = true;
                        stampInjuTouch = false;
                    }
                }

            }

        }

        injuAmount.GetComponent<Image>().fillAmount = ((float)inkValue / 10);
    }

    //인주 닫기
    public void InjuClose()
    {
        SoundManager.soundManager.INZ_2PlaySound();
        stampInjuTap.GetComponent<SpriteRenderer>().enabled = false;
        stampInju.transform.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/StampInjuCloseImg");
        Instantiate(stampInjuAnimation, new Vector2(stampInjuTap.transform.position.x, stampInjuTap.transform.position.y), Quaternion.identity);
        Destroy(GameObject.Find(stampInjuAnimation.name + "(Clone)"), 0.2f);

    }

    public void StampBoardOnOff()
    {
        if (stampTouch == true)
        {
            stampTouch = false;
        }
        else if (stampTouch == false)
        {
            stampTouch = true;
        }
    }

    public void StampOff()
    {
        waxOn = true;
    }

    public void StampOn()
    {
        waxOn = false;
    }

    public void StampBoardReset()
    {
        Debug.Log("23");

        otherTouch = false;
    }
}
