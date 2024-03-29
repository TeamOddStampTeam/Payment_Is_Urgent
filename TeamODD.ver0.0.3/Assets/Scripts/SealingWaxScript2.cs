﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealingWaxScript2 : MonoBehaviour
{
    private bool waxTouch = false;
    private bool success = false;
    private bool otherTouch = false;
    private int TapSpaceSuccess = 0;

    private GameObject wax;

    public GameObject waxAnimation;
    public GameObject stampBurnPrefab;
    public GameObject waxPrefab;

    public Sprite[] WaxPieceSprite;

    // Start is called before the first frame update
    void Start()
    {
        success = false;
        TapSpaceSuccess = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

        if ((!ButtonScript.is_Stop) && Input.GetMouseButtonDown(0))
        {
            if (waxTouch == true)
            {
                if (hit.transform.gameObject.tag == "StampBoard")
                {
                    SoundManager.soundManager.reDZ_2PlaySound();
                    Instantiate(waxPrefab, new Vector2(touchPos.x, touchPos.y), Quaternion.identity);
                    GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().FalseScore();
                    BoardControllerScript.otherTouchCount++;
                    success = false;
                    otherTouch = true;
                }

                if (hit.transform.gameObject.tag == "StampBoardTap")
                {
                    SoundManager.soundManager.reDZ_2PlaySound();
                    Instantiate(waxPrefab, new Vector2(touchPos.x, touchPos.y), Quaternion.identity);
                    GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().FalseScore();
                    BoardControllerScript.otherTouchCount++;
                    success = false;
                    otherTouch = true;
                }

                if (hit.transform.gameObject.tag == "Sign")
                {
                    SoundManager.soundManager.reDZ_2PlaySound();
                    Instantiate(waxPrefab, new Vector2(touchPos.x, touchPos.y), Quaternion.identity);
                    GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().FalseScore();
                    BoardControllerScript.otherTouchCount++;
                    success = false;
                    otherTouch = true;
                }

                if (hit.transform.gameObject.name == "LeterTapSpaceObj")
                {
                    SoundManager.soundManager.reDZ_2PlaySound();
                    TapSpaceSuccess++;
                    if (success == true)
                    {
                        Instantiate(waxPrefab, new Vector2(touchPos.x + 0.1f, touchPos.y + 0.1f), Quaternion.identity);
                        otherTouch = true;
                        BoardControllerScript.otherTouchCount++;
                        GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().FalseScore();
                    }
                    else
                    {
                        hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/StampSealPieceImg");
                        wax = hit.transform.gameObject;
                        success = true;
                        otherTouch = false;
                    }
                }
                else if (hit.transform.gameObject.tag == "Letter")
                {
                    SoundManager.soundManager.reDZ_2PlaySound();
                    Instantiate(waxPrefab, new Vector2(touchPos.x, touchPos.y), Quaternion.identity);
                    success = false;
                    Debug.Log("Letter");
                    otherTouch = true;
                    BoardControllerScript.otherTouchCount++;
                    GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().FalseScore();

                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (!ButtonScript.is_Stop)
        {
            if (waxTouch == false)
            {
                this.gameObject.transform.localScale = new Vector2(0.3f, 0.3f);
                //GameObject.Find("SealingWaxDummyObj").GetComponent<SpriteRenderer>().color = new Color(50f, 50f, 50f,255);

                SoundManager.soundManager.WS_1PlaySound();
                waxTouch = true;
                GameObject.Find("GameController").GetComponent<BoardControllerScript>().StampOff();
                GameObject.Find("SealingWaxStampObj").GetComponent<SealingStampScript>().WaxStampOnOff();

            }
            else
            {
                //왁스 다시 눌러서 취소
                SoundManager.soundManager.WS_closePlaySound();

                this.gameObject.transform.localScale = new Vector2(0.25f, 0.25f);
                //GameObject.Find("SealingWaxDummyObj").GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f,255);

                waxTouch = false;

                GameObject.Find("GameController").GetComponent<BoardControllerScript>().StampOn();

            }
        }
    }

    public void WaxSuccess(float x, float y)
    {
        if (!ButtonScript.is_Stop)
        {
            if(success == true || TapSpaceSuccess > 0)
            {
                Instantiate(waxAnimation, new Vector2(wax.transform.position.x, wax.transform.position.y + 0.5f), Quaternion.identity);
                wax.GetComponent<SpriteRenderer>().sprite = WaxPieceSprite[SaveData.ListNum_S];
                if (otherTouch == false && BoardControllerScript.otherTouchCount == 0)
                {
                    SoundManager.soundManager.WS_2PlaySound();
                    Debug.Log("oT : " + otherTouch + "BoardControllerScript.otherTouchCount" + BoardControllerScript.otherTouchCount);
                    StartCoroutine("FadeOut");
                    GameObject.Find("SealingWaxStampObj").GetComponent<SealingStampScript>().WaxStampOnOff();
                    GameObject.Find("GameController").GetComponent<BoardControllerScript>().StampOn();

                    WaxOnOff();
                }
            }
            else
            {
                Instantiate(stampBurnPrefab, new Vector2(x, y), Quaternion.identity);
                Instantiate(waxAnimation, new Vector2(x, y + 0.5f), Quaternion.identity);
                BoardControllerScript.otherTouchCount++;
            }
        }
    }

    IEnumerator FadeOut()
    {
        GameObject[] letterObjects = GameObject.FindGameObjectsWithTag("Letter");
        GameObject[] waxObjects = GameObject.FindGameObjectsWithTag("Wax");

        for (float f = 1.0f; f >= 0.0; f -= 0.1f)
        {
            Color c0 = letterObjects[0].GetComponent<SpriteRenderer>().color;
            c0.a = f;
            letterObjects[0].GetComponent<SpriteRenderer>().color = c0;

            Color c1 = letterObjects[1].GetComponent<SpriteRenderer>().color;
            c1.a = f;
            letterObjects[1].GetComponent<SpriteRenderer>().color = c1;

            yield return new WaitForSeconds(0.1f);
        }

        for (int i = 0; i < waxObjects.Length; i++)
        {
            Destroy(waxObjects[i]);
        }
        success = false;
        SoundManager.soundManager.LetterSPlaySound();
        GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().LetterScore();
    }

    public void WaxOnOff()
    {
        if ((!ButtonScript.is_Stop) && waxTouch == true)
        {
           
            this.gameObject.transform.localScale = new Vector2(0.25f, 0.25f);
            waxTouch = false;
            GameObject.Find("GameController").GetComponent<BoardControllerScript>().StampOn();
        }

    }

    public void LetterReset()
    {
        GameObject.Find("SealingWaxStampObj").GetComponent<SealingStampScript>().stampReset();
        success = false;
        otherTouch = false;
        TapSpaceSuccess = 0;
        wax.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/None");
    }
}
