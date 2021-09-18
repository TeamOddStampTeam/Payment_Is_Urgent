using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperDragScript : MonoBehaviour
{
    public GameObject dragSpawn;
    public GameObject arrowPrefab;
    public GameObject paperAnim;

    public Collider2D[] hit2;

    private int dragSuccess;

    // Start is called before the first frame update
    void Start()
    {
        dragSuccess = 0;
        Instantiate(arrowPrefab, new Vector2(0.0f, 0.24f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.1f, 0.1f), 0);

        for (int i = 0; i < hit.Length; ++i)
        {
            hit2 = hit;
        }

        for (int i = 0; i < hit2.Length; ++i)
        {
            //정답
            if (hit2[i].name == "PaperDragSuccessPoint")
            {
                dragSuccess++;
                if (dragSuccess == 1)
                {
                    DragDestroy();
                    GameObject.Find("GameController").GetComponent<BoardControllerScript>().StampBoardOnOff();
                    Instantiate(paperAnim);
                    GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().SealingOrAnother();
                }
                break;
            }

            if (hit2[i].name == "Wall")
            {
                gameObject.transform.position = dragSpawn.transform.position;
                hit2 = null;
            }
        }
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
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
