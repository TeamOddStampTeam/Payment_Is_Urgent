using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSignScript : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;
    public List<Vector2> fingerPositions;
    public EdgeCollider2D edgeCollider2D;

    public GameObject dragSpawn;
    public GameObject text;

    private int signSuccess;
    private int signSuccess2;

    public Collider2D[] hit2;

    public AudioClip audioPen;

    // Start is called before the first frame update
    void Start()
    {
        signSuccess = 1;
        signSuccess2 = 1;
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
            if (hit2[i].name == "SignSuccessPointObj")
            {
                signSuccess = 2;
                signSuccess2++;
                if (signSuccess2 == 2)
                {
                    GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().Score();
                    hit2 = null;
                    Instantiate(text, new Vector2(text.transform.position.x, text.transform.position.y), Quaternion.identity);
                }
                break;
            }
            
            if (hit2[i].name == "Wall")
            {
                LineReset();
            }
            
        }
        
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);

        if (signSuccess == 1)
        {
            CreateLine();
        }

        Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f)
        {
            if (signSuccess != 2)
            {
                UpdateLine(tempFingerPos);
            }
        }

        if (signSuccess != 2)
        {
            signSuccess -= 1;

            if (this.transform.position.x > dragSpawn.transform.position.x + 5.0)
            {
                LineReset();
            }

            if (this.transform.position.x < dragSpawn.transform.position.x)
            {
                LineReset();
            }
            if (this.transform.position.y > dragSpawn.transform.position.y + 0.8)
            {
                LineReset();
            }
            if (this.transform.position.y < dragSpawn.transform.position.y - 0.8)
            {
                LineReset();
            }
        }
    }

    private void OnMouseUpAsButton()
    {
        LineReset();
    }

        public void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider2D = currentLine.GetComponent<EdgeCollider2D>();
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);
        edgeCollider2D.points = fingerPositions.ToArray();
    }

    public void UpdateLine(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        edgeCollider2D.points = fingerPositions.ToArray();
    }

    public void LineReset()
    {
        Destroy(currentLine);
        signSuccess = 1;
        gameObject.transform.position = dragSpawn.transform.position;
        hit2 = null;
    }

}
