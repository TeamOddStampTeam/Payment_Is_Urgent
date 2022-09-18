using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealingStampScript : MonoBehaviour
{
    public static bool stampTouch = false;
    private bool success = false;

    public GameObject waxAnimation;
    public GameObject stampBurnPrefab;

    // Start is called before the first frame update
    void Start()
    {
        success = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

        if ((!ButtonScript.is_Stop) && Input.GetMouseButtonDown(0))
        {
            if (stampTouch == true)
            {
                if (hit.transform.gameObject.tag == "StampBoard")
                {
                    SoundManager.soundManager.WS_2PlaySound();
                    Instantiate(stampBurnPrefab, new Vector2(touchPos.x, touchPos.y), Quaternion.identity);
                    Instantiate(waxAnimation, new Vector2(touchPos.x, touchPos.y + 0.5f), Quaternion.identity);
                    GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().FalseScore();
                    BoardControllerScript.otherTouchCount++;
                    success = false;
                }

                if (hit.transform.gameObject.tag == "StampBoardTap")
                {
                    SoundManager.soundManager.WS_2PlaySound();
                    Instantiate(stampBurnPrefab, new Vector2(touchPos.x, touchPos.y), Quaternion.identity);
                    Instantiate(waxAnimation, new Vector2(touchPos.x, touchPos.y + 0.5f), Quaternion.identity);
                    GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().FalseScore();
                    BoardControllerScript.otherTouchCount++;
                    success = false;
                }

                if (hit.transform.gameObject.tag == "Sign")
                {
                    SoundManager.soundManager.WS_2PlaySound();
                    Instantiate(stampBurnPrefab, new Vector2(touchPos.x, touchPos.y), Quaternion.identity);
                    Instantiate(waxAnimation, new Vector2(touchPos.x, touchPos.y + 0.5f), Quaternion.identity);
                    GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().FalseScore();
                    BoardControllerScript.otherTouchCount++;
                    success = false;
                }

                if (hit.transform.gameObject.tag == "Letter")
                {
                    SoundManager.soundManager.WS_2PlaySound();
                    if (hit.transform.gameObject.name != "LeterTapSpaceObj")
                    {
                        success = false;
                        Instantiate(stampBurnPrefab, new Vector2(touchPos.x, touchPos.y), Quaternion.identity);
                        Instantiate(waxAnimation, new Vector2(touchPos.x, touchPos.y + 0.5f), Quaternion.identity);
                        GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().FalseScore();
                        BoardControllerScript.otherTouchCount++;
                    }
                    else
                    { 
                        success = true;
                        Debug.Log("LetterTapSpaceObj");
                        GameObject.Find("SealingWaxDummyObj").GetComponent<SealingWaxScript2>().WaxSuccess(touchPos.x, touchPos.y);
                    }
                }

                if (hit.transform.gameObject.tag == "Wax")
                {
                    SoundManager.soundManager.WS_2PlaySound();
                    GameObject waxPiece = hit.transform.gameObject;
                    waxPiece.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/StampSealBasicImg");
                    Instantiate(waxAnimation, new Vector2(touchPos.x, touchPos.y + 0.5f), Quaternion.identity);
                    success = false;
                    Debug.Log("99");

                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (!ButtonScript.is_Stop)
        {
            if (stampTouch == false)
            {
                SoundManager.soundManager.reDZ_1PlaySound();
                this.gameObject.transform.localScale = new Vector2(0.3f, 0.3f);
                stampTouch = true;

                GameObject.Find("GameController").GetComponent<BoardControllerScript>().StampOff();
                GameObject.Find("SealingWaxDummyObj").GetComponent<SealingWaxScript2>().WaxOnOff();

            }
            else
            {
                //도장 취소
                SoundManager.soundManager.reDZ_closePlaySound();
                this.gameObject.transform.localScale = new Vector2(0.25f, 0.25f);
                stampTouch = false;

                GameObject.Find("GameController").GetComponent<BoardControllerScript>().StampOn();

            }
        }
    }

    public void WaxStampOnOff()
    {
        if (!ButtonScript.is_Stop) 
        {
            if (stampTouch == true)
            {
                this.gameObject.transform.localScale = new Vector2(0.25f, 0.25f);
                stampTouch = false;
                GameObject.Find("GameController").GetComponent<BoardControllerScript>().StampOn();

                Debug.Log("waxstampoff");
            }
        }

    }

    public void stampReset()
    {
        success = false;
    }


}
