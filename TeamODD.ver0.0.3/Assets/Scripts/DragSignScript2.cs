using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSignScript2 : MonoBehaviour
{
    public GameObject signPrefab;
    public GameObject signSpawn;
    Vector2 mouseDownPosition;
    Vector2 mouseUpPosition;

    // Start is called before the first frame update
    void Start()
    {
        
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


        if (mouseUpPosition.x > mouseDownPosition.x + 1.0f)
        {
            if(mouseUpPosition.y + 0.2f > mouseDownPosition.y && 
                mouseDownPosition.y > mouseUpPosition.y -0.2f )
            {
                Instantiate(signPrefab, new Vector2(signSpawn.transform.position.x, signSpawn.transform.position.y), Quaternion.identity);
                GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().Score();
                SoundManager.soundManager.penPlaySound();
                Debug.Log("Success");
            }
        }
    }
}
