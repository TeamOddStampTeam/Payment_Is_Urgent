using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSignScript : MonoBehaviour
{
    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 0.5f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - time);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time);
            if (time > 1.0f && time < 2.0f)
            {
                time = 0;
            }
            else if (time > 2.0f)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            }
        }

        if (time <= 1.0f)
        {
            time += Time.deltaTime;
        }

        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //time = 3.0f;
                Destroy(gameObject);
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            //time = 3.0f;
            Destroy(gameObject);
        }
    }
}
