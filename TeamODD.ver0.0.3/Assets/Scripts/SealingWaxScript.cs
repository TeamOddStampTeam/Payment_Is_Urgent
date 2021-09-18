using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealingWaxScript : MonoBehaviour
{
    public GameObject waxAnimation;

    private bool sealingWaxTouch = false;
    private bool letterTouch = false;
    private bool sealingStampTouch = false;

    // Start is called before the first frame update
    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

        //mouseClick
        if (Input.GetMouseButtonDown(0))
        {
            //왁스 더미 touch
            if (hit.transform.gameObject.name == "SealingWaxDummyObj")
            {
                if (sealingWaxTouch == true)
                {
                    SoundManager.soundManager.WS_1PlaySound();
                    sealingWaxTouch = false;
                }
                sealingWaxTouch = true;
            }

            //도장 touch
            if (hit.transform.gameObject.name == "SealingWaxStampObj")
            {
                SoundManager.soundManager.reDZ_1PlaySound();
                //왁스 더미 touch -> 편지 touch 
                if (letterTouch == true)
                {
                    sealingStampTouch = true;
                }
            }

            //편지 touch
            if (hit.transform.gameObject.name == "LeterTapSpaceObj")
            {
                //왁스 더미 touch
                if(sealingWaxTouch == true)
                {
                    SoundManager.soundManager.reDZ_2PlaySound();
                    letterTouch = true;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/StampSealPieceImg");
                }

                //왁스 더미 touch -> 편지 touch -> 도장 touch 정답!!
                if (sealingStampTouch == true)
                {
                    SoundManager.soundManager.WS_2PlaySound();
                    Instantiate(waxAnimation, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f), Quaternion.identity);
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/StampSealBasicImg");
                    StartCoroutine("FadeOut");
                }
            }
        }
    }

    IEnumerator FadeOut()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Letter");

        for (float f = 1.0f; f >= 0.0; f -= 0.1f)
        {
            Color c0 = gameObjects[0].GetComponent<SpriteRenderer>().color;
            c0.a = f;
            gameObjects[0].GetComponent<SpriteRenderer>().color = c0;

            Color c1 = gameObjects[1].GetComponent<SpriteRenderer>().color;
            c1.a = f;
            gameObjects[1].GetComponent<SpriteRenderer>().color = c1;

            yield return new WaitForSeconds(0.1f);
        }

        SoundManager.soundManager.LetterSPlaySound();
        GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().LetterScore();
    }

}
