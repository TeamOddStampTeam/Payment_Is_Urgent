using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperDragScript2 : MonoBehaviour
{
    public GameObject paperAnim;
    public GameObject arrowPrefab;

    Vector2 mouseDownPosition;
    Vector2 mouseUpPosition;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(arrowPrefab, new Vector2(0.0f, 0.24f), Quaternion.identity);

        GameObject[] stampPrefabs = GameObject.FindGameObjectsWithTag("StampBoard");
        for (int i = 0; i < stampPrefabs.Length; i++)
        {
            stampPrefabs[i].GetComponent<BoxCollider2D>().enabled = false;
        }        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnMouseDown()
    {
        mouseDownPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mouseDownPosition = Camera.main.ScreenToWorldPoint(mouseDownPosition);

        Debug.Log(mouseDownPosition);
        Debug.Log("Down");

    }

    private void OnMouseUp()
    {
        
        mouseUpPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mouseUpPosition = Camera.main.ScreenToWorldPoint(mouseUpPosition);

        Debug.Log(mouseUpPosition);
        Debug.Log("Up");


        if (mouseUpPosition.y > mouseDownPosition.y + 2.5f)
        {
            SoundManager.soundManager.PageSPlaySound();
            Debug.Log("Success");
            DragDestroy();
            GameObject.Find("GameController").GetComponent<BoardControllerScript>().StampBoardOnOff();
            GameObject.Find("SealingWaxDummyObj").GetComponent<SealingWaxScript2>().WaxOnOff();
            GameObject.Find("SealingWaxStampObj").GetComponent<SealingStampScript>().WaxStampOnOff();
            Instantiate(paperAnim);
            GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().SealingOrAnother();

        }
        else
        {
            SoundManager.soundManager.NopePlaySound();
            Debug.Log("fail");
        }
    }

    public void DragDestroy()
    {
        GameObject[] stampPrefabs = GameObject.FindGameObjectsWithTag("StampBoard");
        for (int i = 0; i < stampPrefabs.Length; i++)
        {
            Destroy(stampPrefabs[i]);
        }

        GameObject[] signPrefabs = GameObject.FindGameObjectsWithTag("Sign");
        for (int i = 0; i < signPrefabs.Length; i++)
        {
            Destroy(signPrefabs[i]);
        }

        GameObject[] letterPrefabs = GameObject.FindGameObjectsWithTag("Letter");

        for (int i = 0; i < letterPrefabs.Length; i++)
        {
            Destroy(letterPrefabs[i]);
        }

        GameObject[] linestampPrefabs = GameObject.FindGameObjectsWithTag("LineAndStamp");
        for (int i = 0; i < linestampPrefabs.Length; i++)
        {
            Destroy(linestampPrefabs[i]);
        }

        GameObject[] destroyPrefabs = GameObject.FindGameObjectsWithTag("Destroy");
        for (int i = 0; i < destroyPrefabs.Length; i++)
        {
            Destroy(destroyPrefabs[i]);
        }
    }
}
